using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Rigidbody rigidBody;

    public float moveSpeed = -300f;
    public float health = 15;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
        }
        else if(coll.gameObject.tag == "Bullet")
        {
            Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            if(bullet.type == "Player")
            {
                Damage(bullet.damage);
            }
            
        }
        else if(coll.gameObject.tag == "Bounds_Enemy")
        {
            Destroy(gameObject);
        }
    }

    protected void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();   
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}
