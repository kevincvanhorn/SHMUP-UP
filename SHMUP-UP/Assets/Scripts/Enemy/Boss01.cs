using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss01 : Enemy
{
    public float healthMax;
    public GameObject bullet01, bullet02;
    public GameObject bulletSpawn1, bulletSpawn2, bulletSpawn3, bulletSpawn4;
    public GameObject lazerSpawn1, lazer, lazerParticles;
    public Gun bulletSpawn5;
    public float fireRate = .1f, fireRate02 = .1f;
    public int ammo = 3, ammo02 = 200;
    public TrackMovementSmooth gunTracking;
    public Animator pyramidAnimator;

    public delegate void RotationEvent();
    public static event RotationEvent QueryRotation;

    public delegate void AttackEvent();
    public static event AttackEvent PyramidAttack;

    public float fireSprayShift = 10;

    void Awake()
    {
        gameManager = GameManager.Instance();
    }

    // Use this for initialization
    void Start()
    {
        healthMax = health;
        gameManager.isBossActive = true;
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(7);
        while(health > 0)
        {

        StartCoroutine(FireSpray(4.5f));
        StartCoroutine(FireFour(10));
        StartCoroutine(FireLazer());

        yield return new WaitWhile(() => ammo > 0);
        fireRate02 = 0.05f;
        bulletSpawn5.rotateRate = 45;
        ammo02 = 400;
        StartCoroutine(FireSpray(0));
        StartCoroutine(FireSprayShift());
        StartCoroutine(FireLazer());
        // send out triangle here
        yield return new WaitForSeconds(8f);

        pyramidAnimator.SetBool("firePyramid", true);
        if (PyramidAttack != null)
            PyramidAttack(); // Call the event.
        yield return new WaitForSeconds(10);
        pyramidAnimator.SetBool("firePyramid", false);

        yield return new WaitForSeconds(6f);
        fireRate02 = 0.05f;
        bulletSpawn5.rotateRate = 9.86f;

        pyramidAnimator.SetBool("firePyramid", true);
        if (PyramidAttack != null)
            PyramidAttack(); // Call the event.
        yield return new WaitForSeconds(10);
        pyramidAnimator.SetBool("firePyramid", false);

        yield return new WaitWhile(() => ammo02 > 0);
        StartCoroutine(FireLazer());

        yield return null;

        ammo = 50;
        StartCoroutine(FireFour(20));
        }
    }

    IEnumerator FireLazer()
    {
        GameObject newLazerParticles = Instantiate(lazerParticles, lazerSpawn1.transform.position, lazerSpawn1.transform.rotation);
        newLazerParticles.transform.parent = lazerSpawn1.transform;
        yield return new WaitForSeconds(2);

        GameObject newLazer = Instantiate(lazer, lazerSpawn1.transform.position, lazerSpawn1.transform.rotation);
        newLazer.transform.parent = lazerSpawn1.transform;
        
        yield return null;
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
        gameManager.isBossActive = false;
        base.Die();
        //Instantiate(particlesDeath, transform.position, particlesDeath.transform.rotation);
    }

}
