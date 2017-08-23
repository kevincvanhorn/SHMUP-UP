using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawner : MonoBehaviour {

    public Player player;
    public GameObject playerSpawn;

    private GameManager gameManager;


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
        Instantiate(player, playerSpawn.transform.position, player.transform.rotation);
    }

    public void OnPlayerDie()
    {
        print("NOOOOOOOOOOOOOOOOOOOO!");
        gameManager.Lives--;
        StartCoroutine(DelayedSpawn());
    }

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1);
        if(!gameManager.isGameOver)
            SpawnPlayer();
    }
}
