using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody rigidBody;
    public float moveSpeed = -500f;
    public float damage = 1;
    public string type; // "Player" or "Enemy"
    public GameObject explosion;


    protected GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance();
    }

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
        else if(type == "Player"){
            if(coll.gameObject.tag == "Enemy")
            {
                Instantiate(explosion, transform.position+new Vector3(0,0,-50f), explosion.transform.rotation);
                Destroy(gameObject);
            }
        }
        else if(type == "Enemy")
        {
            if (coll.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        
    }
}
