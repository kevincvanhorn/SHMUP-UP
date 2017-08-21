using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour {

    public bool hasParent = false;

    private void Start()
    {
        
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }

    void OnDestroy()
    {
        if (hasParent)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
