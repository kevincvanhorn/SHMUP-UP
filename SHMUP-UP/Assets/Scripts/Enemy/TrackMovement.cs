using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour {
    Transform player;
    float speedMultiplier = 1;//5f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player_01").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(player, transform.up);
        //transform.rotation = Quaternion.Euler(new Vector3(-90, 0, transform.rotation.z));

        Vector3 targetPostition = new Vector3(player.transform.position.x,this.transform.position.y,player.position.z);
        this.transform.LookAt(targetPostition);
    }
}
