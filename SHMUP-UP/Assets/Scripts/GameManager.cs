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
    public bool isGameWin = false;
    public bool isBossActive = false;

    public Text scoreText;
    public Text livesText;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
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
        gameWinPanel.gameObject.SetActive(false);

        healthBarGreen.gameObject.SetActive(false);
        healthBarRed.gameObject.SetActive(false);

        if (difficulty == 0)
            lives = 40;
        else if (difficulty == 1)
            lives = 30;
        else if (difficulty == 2)
            lives = 20;

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
        while (isActiveAndEnabled && !isGameOver && !isGameWin)
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
        Text scoresText = gameOverPanel.transform.Find("ScoreInt").GetComponent<Text>();
        Text killsText = gameOverPanel.transform.Find("KillsInt").GetComponent<Text>();
        scoresText.text = score.ToString();
        killsText.text = kills.ToString();
    }

    public void onGameWin()
    {
        isGameWin = true;
        gameWinPanel.gameObject.SetActive(true);
        Text scoresText = gameWinPanel.transform.Find("ScoreInt").GetComponent<Text>();
        Text killsText = gameWinPanel.transform.Find("KillsInt").GetComponent<Text>();
        Text livesText = gameWinPanel.transform.Find("LivesInt").GetComponent<Text>();
        livesText.text = lives.ToString();
        scoresText.text = score.ToString();
        killsText.text = kills.ToString();
        scoreText.gameObject.SetActive(false);
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
