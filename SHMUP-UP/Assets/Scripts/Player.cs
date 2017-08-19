using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour {

    public Rigidbody rigidBody; // Not Kinematic: moves not by transform, but by physics
    public CollisionInfo collisions;
    public float moveSpeed = 300f;

    private Vector3 velocity;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        velocity = new Vector3(0, 0, 0);

        collisions.isRightPressed = false;
        collisions.isLeftPressed = false;
        collisions.isUpPressed = false;
        collisions.isDownPressed = false;
    }
	
	// Update is called once per frame
	void Update () {

        Movement();
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

    public void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    void onCollisionEnter(Collision coll)
    {
        print("collisions");
        if(coll.gameObject.tag == "Enemy")
        {
            die();
        }
    }

    void onTriggerEnter(Collider other)
    {
        print("MAX TRigger");
    }

    void die()
    {
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