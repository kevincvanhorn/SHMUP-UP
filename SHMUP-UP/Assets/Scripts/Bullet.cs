using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody rigidBody;
    public float moveSpeed = -500f;
    public float damage = 1;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = rigidBody.position;
        rigidBody.MovePosition(new Vector3(position.x, position.y, position.z + moveSpeed*Time.deltaTime));
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
        else if(coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
