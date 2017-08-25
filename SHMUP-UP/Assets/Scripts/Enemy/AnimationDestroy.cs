using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroy : MonoBehaviour {

    public float delay = 0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, delay); //this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 
    }
}
