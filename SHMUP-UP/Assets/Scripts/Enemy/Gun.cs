using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Boss01 boss;
    public bool canRotate = true;
    public float rotateRate = 7;

    private float dir = -1;

    // Use this for initialization
    void Start () {
        Boss01.QueryRotation += RotationEvent;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotationEvent()
    {
        if (transform.localRotation.eulerAngles.z < 45)
            dir = 1;
        else if (transform.localRotation.eulerAngles.z > 315)
            dir = -1;
        if (canRotate)
        {
            transform.Rotate(new Vector3(0, 0, dir * rotateRate));
        }
    }

    public void Rotate(float degrees)
    {
        transform.Rotate(new Vector3(0, 0, dir * degrees));
    }

    void OnDisable()
    {
        Boss01.QueryRotation -= RotationEvent;
    }
}
