using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public bool isPlayerAlive = true;

    /* Modified Singleton-Style, static reference */
    // By calling modalPanel.Instance, it will return a reference to this script.
    public static GameManager Instance()
    {
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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
