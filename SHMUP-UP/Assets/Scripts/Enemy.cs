using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody rigidBody;

    public float moveSpeed = -300f;
    public float health;
    public float firerate;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = rigidBody.position;
        rigidBody.MovePosition(new Vector3(position.x, position.y, position.z + moveSpeed*Time.deltaTime));
    }

    void onCollisionEnter(Collision coll)
    {
        print("COLLISIONS");
    }
}
