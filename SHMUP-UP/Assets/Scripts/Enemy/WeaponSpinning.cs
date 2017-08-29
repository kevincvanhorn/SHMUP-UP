using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpinning : MonoBehaviour {
    public GameObject bullet;
    public GameObject bulletSpawn1, bulletSpawn2, bulletSpawn3;
    public float fireRate = .1f;
    public int ammo = 3;

    void Start()
    {
        Boss01.PyramidAttack += PyramidAttack;
    }

    void PyramidAttack()
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
            yield return new WaitForSeconds(fireRate);
        }
        ammo = 50;
    }

    void OnDisable()
    {
        Boss01.PyramidAttack -= PyramidAttack;
    }
}
