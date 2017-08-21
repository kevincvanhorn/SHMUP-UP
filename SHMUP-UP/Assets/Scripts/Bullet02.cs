using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02 : Bullet
{
    private Vector3 velocity;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        type = "Enemy";
        rigidBody = GetComponent<Rigidbody>();

        GameObject go = GameObject.Find("Player_01");
        target = go.transform;
        transform.LookAt(new Vector3(target.transform.position.x,this.transform.position.y,target.transform.position.z));
        transform.Rotate(new Vector3(90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.up;
        //rigidBody.MovePosition(rigidBody.position + (rot*moveSpeed) * Time.deltaTime);
        rigidBody.velocity = rot * moveSpeed;
    }
}
