using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet04 : Bullet
{
    public float lifeTime = 2;
    public float rotationRate;

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
        transform.Rotate(0, 0, rotationRate * Time.deltaTime);
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
