using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawner : MonoBehaviour {

    //private static PlayerSpawner playerSpawner;

    public delegate void PlayerSpawnDelegate();
    public static event PlayerSpawnDelegate OnPlayerDeath;
    public static event PlayerSpawnDelegate OnPlayerSpawn;

    public Player player;
    public GameObject playerSpawn;
    private GameManager gameManager;

    /* Modified Singleton-Style, static reference */
    // By calling modalPanel.Instance, it will return a reference to this script.
    /*public static PlayerSpawner Instance()
    {
        // Maintain one copy through scene reload.
        if (!playerSpawner)
        {
            playerSpawner = FindObjectOfType(typeof(PlayerSpawner)) as PlayerSpawner;
            if (!playerSpawner)
                Debug.LogError("There needs to be one active GameManager script on a GameObject in the scene.");
        }

        return playerSpawner;
    }*/

    void Awake()
    {
        gameManager = GameManager.Instance();
    }

    // Use this for initialization
    void Start () {
        SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPlayer()
    {
        if (!gameManager.isPlayerAlive)
        {
            gameManager.isPlayerAlive = true;
            Instantiate(player, playerSpawn.transform.position, player.transform.rotation);
            StartCoroutine(MakeInvulnerable());
            if (OnPlayerSpawn != null)
                OnPlayerSpawn();
        }
        
    }

    public void OnPlayerDie()
    {
        gameManager.Lives--;
        if (OnPlayerDeath != null)
            OnPlayerDeath();
        StartCoroutine(DelayedSpawn());
    }

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1);
        if(!gameManager.isGameOver)
            SpawnPlayer();
    }

    IEnumerator MakeInvulnerable()
    {
        gameManager.isPlayerInvunlverable = true;
        yield return new WaitForSeconds(2.5f);
        gameManager.isPlayerInvunlverable = false;
    }
}
