using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet03 : Bullet
{
    private Vector3 velocity;
    private Transform target;
    private Vector3 rot;

    // Use this for initialization
    void Start()
    {
        type = "Enemy";
        rigidBody = GetComponent<Rigidbody>();
        rot = transform.up;

        StartCoroutine(DelayedDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = rot * moveSpeed;
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
