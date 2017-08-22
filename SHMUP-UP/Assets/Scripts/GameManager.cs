using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public bool isPlayerAlive = true;

    public Text scoreText;
    public int score;

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
        GameObject.DontDestroyOnLoad(gameObject);
        StartCoroutine("AddScore");
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
            
        }
            
    }

    IEnumerator AddScore()
    {
        while (isActiveAndEnabled && isPlayerAlive)
        {
            yield return new WaitForSeconds(.05f);
            score++;
        }
        
    }
}
