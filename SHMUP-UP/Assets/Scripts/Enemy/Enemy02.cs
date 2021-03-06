﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : Enemy {

    public GameObject bullet, bulletSpawn1;
    public GameObject gunParent;
    public float fireRate = .1f;
    public int ammo = 3;

    private Animator animator;

    public GameObject particlesDeath;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        if(transform.position.x < -100)
            animator.SetBool("isFlipped",true);
        //bulletSpawn1 = transform.Find("BulletSpawn_01").gameObject;
        StartCoroutine(Fire());
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = rigidBody.position;
        rigidBody.MovePosition(new Vector3(position.x, position.y, position.z + moveSpeed * Time.deltaTime));
    }


    IEnumerator Fire()
    {
        yield return new WaitForSeconds(3f);
        while (ammo >0 && gameManager.isPlayerAlive) {//(isActiveAndEnabled && gameManager.isPlayerAlive) {
            Vector3 rot = new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, bulletSpawn1.transform.rotation.z);
            Instantiate(bullet, bulletSpawn1.transform.position, bullet.transform.rotation);
            ammo--;
            yield return new WaitForSeconds(.5f);
        }
    }

    protected override void Die()
    {
        base.Die();
        Instantiate(particlesDeath, transform.position, particlesDeath.transform.rotation);
    }

}
