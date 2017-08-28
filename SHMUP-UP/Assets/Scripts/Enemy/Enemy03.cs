﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : Enemy
{

    public GameObject bullet;
    public GameObject bulletSpawn1, bulletSpawn2, bulletSpawn3;
    public int ammo = 3;
    public float firerate;

    private float timeLastFire = 0;

    //public GameObject particlesDeath;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);
        while (ammo > 0) // && gameManager.isPlayerAlive)
        {
            Instantiate(bullet, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
            Instantiate(bullet, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
            Instantiate(bullet, bulletSpawn3.transform.position, bulletSpawn3.transform.rotation);
            ammo--;
            yield return new WaitForSeconds(firerate);
        }
    }

    protected override void Die()
    {
        base.Die();
        //Instantiate(particlesDeath, transform.position, particlesDeath.transform.rotation);
    }

}
