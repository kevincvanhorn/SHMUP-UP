using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour {

    public Rigidbody rigidBody; // Not Kinematic: moves not by transform, but by physics
    public CollisionInfo collisions;
    public float moveSpeed = 300f;
    public GameObject bullet;
    public float fireRate = .1f;
    public GameObject particlesDeath;

    private Vector3 velocity;
    private GameObject bulletSpawn1, bulletSpawn2;
    
    private float timeLastFire = 0;
    

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        velocity = new Vector3(0, 0, 0);

        collisions.isRightPressed = false;
        collisions.isLeftPressed = false;
        collisions.isUpPressed = false;
        collisions.isDownPressed = false;

        bulletSpawn1 = transform.Find("BulletSpawn_01").gameObject;
        bulletSpawn2 = transform.Find("BulletSpawn_02").gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        Movement();
        CheckFire();
    }

    void Movement()
    {
        /* Set velocity by input. */
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            collisions.isUpPressed = true;
            velocity.z = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            collisions.isDownPressed = true;
            velocity.z = -1*moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            collisions.isRightPressed = true;
            velocity.x = moveSpeed; 
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            collisions.isLeftPressed = true;
            velocity.x = -1*moveSpeed;
        }

       

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            collisions.isUpPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            collisions.isDownPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            collisions.isRightPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            collisions.isLeftPressed = false;
        }

        //---------------

        if (!collisions.isRightPressed && !collisions.isLeftPressed)
        {
            velocity.x = 0;
        }
        if (!collisions.isUpPressed && !collisions.isDownPressed)
        {
            velocity.z = 0;
        }

        //print(velocity);
        //rigidBody.velocity = velocity;
        rigidBody.MovePosition(rigidBody.position + velocity * Time.deltaTime);
        //print(GetComponent<Rigidbody>().velocity);
        //rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0));
        //rigidBody.AddForce(new Vector3(0, 0, Input.GetAxis("Vertical") * moveSpeed));
    }

    public void CheckFire()
    {
        timeLastFire += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeLastFire >= fireRate)
        {
            Fire();
            timeLastFire = 0;
        }
    }

    void Fire()
    {
        Instantiate(bullet, bulletSpawn1.transform.position, bullet.transform.rotation);
        Instantiate(bullet, bulletSpawn2.transform.position, bullet.transform.rotation);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            die();
        }
    }

    void die()
    {
        Instantiate(particlesDeath, transform.position, particlesDeath.transform.rotation);
        Destroy(gameObject);  
    }
}


public struct CollisionInfo
{
    public bool isRightPressed;
    public bool isLeftPressed;
    public bool isUpPressed;
    public bool isDownPressed;
}