using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss01 : Enemy
{

    public GameObject bullet01, bullet02;
    public GameObject bulletSpawn1, bulletSpawn2, bulletSpawn3, bulletSpawn4;
    public Gun bulletSpawn5;
    public float fireRate = .1f, fireRate02 = .1f;
    public int ammo = 3, ammo02 = 200;
    public TrackMovementSmooth gunTracking;

    public delegate void RotationEvent();
    public static event RotationEvent QueryRotation;

    public float fireSprayShift = 10;

    private float timeLastFire = 0;

    //public GameObject particlesDeath;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Fire());
    }

    void RotateSpray(float delay)
    {
        StartCoroutine(FireSpray(delay));
        
    }

    IEnumerator Fire()
    {
        RotateSpray(4.5f);
        StartCoroutine(FireFour(10));

        yield return new WaitWhile(() => ammo > 0);
        fireRate02 = 0.05f;
        bulletSpawn5.rotateRate = 45;
        ammo02 = 500;
        StartCoroutine(FireSpray(0));
        StartCoroutine(FireSprayShift());

        yield return null;

        ammo = 200;
        StartCoroutine(FireFour(20));
    }

    IEnumerator FireSpray(float delay)
    {
        yield return new WaitForSeconds(delay);
        while (ammo02 > 0) //&& gameManager.isPlayerAlive)
        {//(isActiveAndEnabled && gameManager.isPlayerAlive) {
            if (QueryRotation != null)
                QueryRotation(); // Call the event.

            Instantiate(bullet02, bulletSpawn5.transform.position, bulletSpawn5.transform.rotation);
            ammo02--;
            yield return new WaitForSeconds(fireRate02);
        }
    }

    IEnumerator FireFour(float burstAmmo)
    {
        float burstAmmo01 = burstAmmo;

        yield return new WaitForSeconds(1.2f);
        while (ammo > 0)
        {
            while (burstAmmo01 > 0) //&& gameManager.isPlayerAlive)
            {
                Instantiate(bullet01, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
                Instantiate(bullet01, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
                Instantiate(bullet01, bulletSpawn3.transform.position, bulletSpawn3.transform.rotation);
                Instantiate(bullet01, bulletSpawn4.transform.position, bulletSpawn4.transform.rotation);

                gunTracking.canTrack = false;
                ammo--;
                burstAmmo01--;
                gunTracking.canTrack = true;
                yield return new WaitForSeconds(fireRate);
            }
            yield return new WaitForSeconds(2);
            burstAmmo01 = burstAmmo;
        }
    }

    IEnumerator FireSprayShift()
    {
        while(ammo02 > 0)
        {
            yield return new WaitForSeconds(2.5f);
            bulletSpawn5.Rotate(fireSprayShift);
        }
    }

    protected override void Die()
    {
        base.Die();
        //Instantiate(particlesDeath, transform.position, particlesDeath.transform.rotation);
    }

}
