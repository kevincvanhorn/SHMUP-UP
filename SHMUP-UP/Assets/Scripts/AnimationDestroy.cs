using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroy : MonoBehaviour {

    public bool hasParent = false;

    private void Start()
    {
        //Destroy(gameObject, GetComponent<Animation>().main.duration);
    }

    void OnDestroy()
    {
        if (hasParent)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
