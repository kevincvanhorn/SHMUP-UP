using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Enemy[] enemies;

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

        yield return new WaitForSeconds(1);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ);
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 3, 120, 0, -120, spawnZ);

        yield return new WaitForSeconds(1);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ);
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 3, 120, 0, -120, spawnZ);

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

        StartCoroutine(SpawnLoop());
        
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

    IEnumerator SpawnLoop()
    {
        for(int i=0; i<2000; i++)
        {
            int randEnemy = (int)Random.Range(0, enemies.Length);
            Instantiate(enemies[randEnemy], new Vector3(Random.Range(spawnXMin, spawnXMax), spawnY, spawnZ), enemies[randEnemy].transform.rotation);
            yield return new WaitForSeconds(.5f);
        }
        
    }
}
