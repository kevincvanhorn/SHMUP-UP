using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : Enemy {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = rigidBody.position;
        rigidBody.MovePosition(new Vector3(position.x, position.y, position.z + moveSpeed * Time.deltaTime));
    }
}
