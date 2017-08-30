using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public bool isPlayerAlive = true;
    public bool isPlayerInvunlverable = false;
    public bool isGameOver = false;
    public bool isBossActive = false;

    public Text scoreText;
    public Text livesText;
    public GameObject gameOverPanel;
    public Image healthBarGreen, healthBarRed;

    public int score;
    public int kills;
    public int lives;
    public int difficulty;

    private Options options;


    void Awake()
    {
        options = Options.Instance();
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            UpdateLives();
        }

    }

    /* Modified Singleton-Style, static reference */
    // By calling modalPanel.Instance, it will return a reference to this script.
    public static GameManager Instance()
    {
        // Maintain one copy through scene reload.
        if (!gameManager)
        {
            gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
            if (!gameManager)
                Debug.LogError("There needs to be one active GameManager script on a GameObject in the scene.");
        }

        return gameManager;
    }

    // Use this for initialization
    void Start () {

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.gameObject.SetActive(false);

        healthBarGreen.gameObject.SetActive(false);
        healthBarRed.gameObject.SetActive(false);

        Lives = lives;
        StartCoroutine("AddScore");
        StartCoroutine(DisplayHealth());

        difficulty = options.difficulty;
        print(difficulty);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
            
        }
        print(difficulty);
    }

    IEnumerator AddScore()
    {
        while (isActiveAndEnabled && !isGameOver)
        {
            yield return new WaitForSeconds(.05f);
            score++;
        }
        
    }

    public void UpdateLives()
    {
        livesText.text = lives.ToString();
        if(lives <= 0)
        {
            onGameOver();
        }
    }

    void onGameOver()
    {
        isGameOver = true;
        gameOverPanel.gameObject.SetActive(true);
        Text scoreText = gameOverPanel.transform.Find("ScoreInt").GetComponent<Text>();
        Text killsText = gameOverPanel.transform.Find("KillsInt").GetComponent<Text>();
        scoreText.text = score.ToString();
        killsText.text = kills.ToString();
    }

    IEnumerator DisplayHealth()
    {
        yield return new WaitWhile(() => isBossActive != true);
        healthBarGreen.gameObject.SetActive(true);
        healthBarRed.gameObject.SetActive(true);

        Boss01 boss01 = GameObject.FindObjectOfType<Boss01>();
        float healthDivider = (1 / boss01.healthMax) * 100;

       

        while (isBossActive)
        {
            healthBarGreen.rectTransform.sizeDelta = new Vector2(boss01.health * healthDivider, 4.84f);
            yield return new WaitForEndOfFrame();
        }

        healthBarRed.gameObject.SetActive(false);
    }
}
