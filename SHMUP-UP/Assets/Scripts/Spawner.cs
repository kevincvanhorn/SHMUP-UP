using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;

    private float spawnXMin = -650;
    private float spawnXMax = 650;
    private float spawnY = 62;
    private float spawnZ = 630;

	// Use this for initialization
	void Start () {
        //InvokeRepeating("Spawn", 5, 2);
        StartCoroutine("Spawn"); //StopCoroutine //StartCoroutine(Spawn()); - alternate method
    }
	
	IEnumerator Spawn()
    {

        //yield return null;

        yield return new WaitForSeconds(1);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ);
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 3, 120, 0, -120, spawnZ);

        yield return new WaitForSeconds(2);
        SpawnAcross(0, 3, 120, 0, -120, spawnZ+240);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ);
        yield return new WaitForSeconds(.5f);

        StartCoroutine(SpawnLoop(0,.5f));
        StartCoroutine(SpawnLoop(1, 3f));
        StartCoroutine(SpawnLoop(2, 8f));

    }

    /*IEnumerator SpawnAcross(int enemy, int numAcross, float spacing, float spawnXStart, float spawnDelay)
    {
        float spawnXCur = spawnXStart;
        for (int i = 0; i < numAcross; i++)
        {
            Instantiate(enemies[0], new Vector3(spawnXCur, spawnY, spawnZ), enemies[0].transform.rotation);
            spawnXCur += spacing;
            yield return null; // wait for end of frame.
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }*/

    void SpawnAcross(int enemy, int numAcross, float spacingX, float spacingZ, float spawnXStart, float spawnZStart)
    {
        float spawnXCur = spawnXStart;
        float spawnZCur = spawnZStart;

        for (int i = 0; i < numAcross; i++)
        {
            Instantiate(enemies[0], new Vector3(spawnXCur, spawnY, spawnZCur), enemies[0].transform.rotation);
            spawnXCur += spacingX;
            spawnZCur += spacingZ;
        }
    }

    IEnumerator SpawnLoop(int enemy, float frequency)
    {
        float mySpawnZ = spawnZ;
        float mySpawnY = spawnY;
        float mySpawnXMin = spawnXMin;
        float mySpawnXMax = spawnXMax;

        if (enemy == 1)
        {
            mySpawnY = 0;
            mySpawnXMin = -650;
            mySpawnXMax = 320;
        }

        if (enemy == 2)
        {
            mySpawnY = 0;
            mySpawnXMin = -380;
            mySpawnXMax = 600;
        }

        for (int i=0; i<2000; i++)
        {
            if (enemy == 1)
                mySpawnZ = Random.Range(0, 455);
            if (enemy == 2)
                mySpawnZ = Random.Range(1100, 1500);

            //int randEnemy = (int)Random.Range(0, enemies.Length);
            Instantiate(enemies[enemy], new Vector3(Random.Range(mySpawnXMin, mySpawnXMax), mySpawnY, mySpawnZ), enemies[enemy].transform.rotation);
            yield return new WaitForSeconds(frequency);
        }
        
    }
}
