using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02 : MonoBehaviour
{

    public Rigidbody rigidBody;
    public float moveSpeed = -500f;
    public float damage = 1;
    public string type = "Enemy"; // "Player" or "Enemy"

    private Vector3 velocity;

    private Transform target;

    // Use this for initialization
    void Start()
    {
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
        rigidBody.MovePosition(rigidBody.position + (rot*moveSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
        else if (type == "Player")
        {
            if (coll.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
        else if (type == "Enemy")
        {
            if (coll.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

    }
}
