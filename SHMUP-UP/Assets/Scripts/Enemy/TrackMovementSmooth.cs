using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovementSmooth : MonoBehaviour
{
    Transform player;
    public float speedMultiplier = 1;
    public bool canTrack = true;

    private Transform RotTransform;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance();
    }

    // Use this for initialization
    void Start()
    {
        PlayerSpawner.OnPlayerSpawn += OnPlayerSpawn;

        if (gameManager.isPlayerAlive)
            player = GameObject.FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPlayerAlive && canTrack)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, this.transform.position.y, player.position.z);
            var rotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speedMultiplier);

        }
    }

    void OnPlayerSpawn()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
    }

    void OnDisable()
    {
        PlayerSpawner.OnPlayerSpawn -= OnPlayerSpawn;
    }
}
