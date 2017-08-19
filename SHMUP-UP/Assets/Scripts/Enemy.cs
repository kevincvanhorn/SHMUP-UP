using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody rigidBody;

    public float moveSpeed = -300f;
    public float health = 15;
    public float firerate;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        print(health);
        Vector3 position = rigidBody.position;
        rigidBody.MovePosition(new Vector3(position.x, position.y, position.z + moveSpeed*Time.deltaTime));
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
        }
        else if(coll.gameObject.tag == "BulletPlayer")
        {
            Damage(coll.gameObject.GetComponent<Bullet>().damage);
        }
    }

    private void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();   
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
