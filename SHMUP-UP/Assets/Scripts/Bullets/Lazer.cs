using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {

    public Rigidbody rigidBody;
    public float damage = 1;
    public string type; // "Player" or "Enem

    // Use this for initialization
    void Start()
    {
        type = "Enemy";
        rigidBody = GetComponent<Rigidbody>();
    }
}
