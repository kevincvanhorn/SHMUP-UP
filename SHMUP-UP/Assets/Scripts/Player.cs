using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour {

    public Rigidbody rigidBody; // Not Kinematic: moves not by transform, but by physics
    public CollisionInfo collisions;
    public float moveSpeed = 300f;
    public GameObject bullet;
    public float fireRate = .1f;
    public GameObject particlesDeath;

    public float moveXMin = -660;
    public float moveXMax = 660;
    public float moveZMin = 480;
    public float moveZMax = -480;

    public UnityEvent playerDeath;

    private Vector3 velocity;
    private GameObject bulletSpawn1, bulletSpawn2;
    
    private float timeLastFire = 0;
    private float diagSpeedX, diagSpeedZ;
    private float xDir, zDir;
    private Vector3 newPos;

    private GameManager gameManager;


    void Awake()
    {
        gameManager = GameManager.Instance();
    }

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        velocity = new Vector3(0, 0, 0);

        collisions.isRightPressed = false;
        collisions.isLeftPressed = false;
        collisions.isUpPressed = false;
        collisions.isDownPressed = false;

        bulletSpawn1 = transform.Find("BulletSpawn_01").gameObject;
        bulletSpawn2 = transform.Find("BulletSpawn_02").gameObject;

        diagSpeedX = moveSpeed * Mathf.Cos(45 * Mathf.Deg2Rad);
        diagSpeedZ = moveSpeed * Mathf.Sin(45*Mathf.Deg2Rad);

        xDir = 1;
        zDir = 1;

        if (playerDeath == null)
            playerDeath = new UnityEvent();
        PlayerSpawner playerSpawner = FindObjectOfType<PlayerSpawner>();
        playerDeath.AddListener(playerSpawner.OnPlayerDie);
        gameManager.isPlayerAlive = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        CheckFire();
        //Debug.Log(velocity + " x:" +xDir + " z:"+zDir);
    }

    void Movement()
    {
        /* Set velocity by input. */
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            collisions.isUpPressed = true;
            zDir = 1;
            if(collisions.isLeftPressed || collisions.isRightPressed)
            {
                velocity.z = diagSpeedZ;
                velocity.x = diagSpeedX * xDir;
            }
            else
                velocity.z = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            collisions.isDownPressed = true;
            zDir = -1;
            if (collisions.isLeftPressed || collisions.isRightPressed)
            {
                velocity.z = -1*diagSpeedZ;
                velocity.x = diagSpeedX * xDir;
            }
            else
                velocity.z = -1*moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            collisions.isRightPressed = true;
            xDir = 1;
            if (collisions.isUpPressed || collisions.isDownPressed)
            {
                velocity.x = diagSpeedX;
                velocity.z = diagSpeedZ * zDir;
            }
            else
                velocity.x = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            collisions.isLeftPressed = true;
            xDir = -1;
            if (collisions.isUpPressed || collisions.isDownPressed)
            {
                velocity.x = -1*diagSpeedX;
                velocity.z = diagSpeedZ * zDir;
            }
            else
                velocity.x = -1*moveSpeed;
        }

       /*On Key Release*/

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            collisions.isUpPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            collisions.isDownPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            collisions.isRightPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            collisions.isLeftPressed = false;
        }

        //---------------
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //TODO
        }

        //------------

        if (!collisions.isRightPressed && !collisions.isLeftPressed)
        {
            velocity.x = 0;
        }
        if (!collisions.isUpPressed && !collisions.isDownPressed)
        {
            velocity.z = 0;
        }
        if(collisions.isUpPressed && !collisions.isLeftPressed && !collisions.isRightPressed)
        {
           velocity.z = moveSpeed * zDir;
        }
        else if (collisions.isDownPressed && !collisions.isLeftPressed && !collisions.isRightPressed)
        {
            velocity.z = moveSpeed * zDir;
        }
        else if (collisions.isLeftPressed && !collisions.isUpPressed && !collisions.isDownPressed)
        {
            velocity.x = moveSpeed * xDir;
        }
        else if (collisions.isRightPressed && !collisions.isUpPressed && !collisions.isDownPressed)
        {
            velocity.x = moveSpeed *xDir;
        }

        //rigidBody.velocity = velocity;
        //Debug.Log(rigidBody.velocity);
        newPos = rigidBody.position + velocity * Time.deltaTime;
        if (newPos.x < moveXMin || newPos.x > moveXMax)
        {
            newPos.x = transform.position.x;
        }
        if (newPos.z > moveZMin || newPos.z < moveZMax)
        {
            newPos.z = transform.position.z;
        }
        rigidBody.MovePosition(newPos);
        


        //print(GetComponent<Rigidbody>().velocity);
        //rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0));
        //rigidBody.AddForce(new Vector3(0, 0, Input.GetAxis("Vertical") * moveSpeed));
    }

    public void CheckFire()
    {
        timeLastFire += Time.deltaTime;
        if (Input.GetKey(KeyCode.X) && timeLastFire >= fireRate)
        {
            Fire();
            timeLastFire = 0;
        }
    }

    void Fire()
    {
        Instantiate(bullet, bulletSpawn1.transform.position, bullet.transform.rotation);
        Instantiate(bullet, bulletSpawn2.transform.position, bullet.transform.rotation);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Die();
        }

        else if (coll.gameObject.tag == "Bullet")
        {
            Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            if (bullet.type == "Enemy")
            {
                Die();
            }

        }
    }

    void OnParticleCollision(GameObject other)
    {
        Die();
    }

    void Die()
    {
        gameManager.isPlayerAlive = false;
        Instantiate(particlesDeath, transform.position, particlesDeath.transform.rotation);
        playerDeath.Invoke();
        Destroy(gameObject);
    }
}


public struct CollisionInfo
{
    public bool isRightPressed;
    public bool isLeftPressed;
    public bool isUpPressed;
    public bool isDownPressed;
}