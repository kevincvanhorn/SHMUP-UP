using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;

    private float spawnXMin = -520;
    private float spawnXMax = 520;
    private float spawnY = 62;
    private float spawnZ = 800;

	// Use this for initialization
	void Start () {
        //InvokeRepeating("Spawn", 5, 2);
        StartCoroutine("Spawn"); //StopCoroutine //StartCoroutine(Spawn()); - alternate method
    }
	
	IEnumerator Spawn()
    {

        /*Spawn Red Waves*/
        
        yield return new WaitForSeconds(1);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);  // Left Out    "/".
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ); // Right Out          "\".
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 1, 0, 0, 0, spawnZ + 120);              // Middle         "."
        SpawnAcross(0, 2, 240, 0, -120, spawnZ);   // Middle Front  "- -"
        yield return new WaitForSeconds(.8f);

        SpawnAcross(0, 2, 240, 0, -120, spawnZ);         // Middle        "- -"
        SpawnAcross(0, 1, 0, 0, 0, spawnZ - 120);        // Middle Front   "."
        yield return new WaitForSeconds(.5f);
       
        SpawnAcross(0, 3, 120, 0, -120, spawnZ+240);     // Middle Across "---".
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);  // Left Out    "/".
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ); // Right Out          "\".
        yield return new WaitForSeconds(.5f);

        SpawnAcross(0, 3, 120, 0, -120, spawnZ);         // Middle Across "---".
        SpawnAcross(0, 3, 120, 0, spawnXMin, spawnZ);    // Left Across "---"
        SpawnAcross(0, 3, -120, 0, spawnXMax, spawnZ);   // Right Across      "---"
        yield return new WaitForSeconds(.5f);

        SpawnAcross(0, 1, 0, 0, 0, spawnZ + 120);              // Middle         "."
        SpawnAcross(0, 2, 240, 0, -120, spawnZ);   // Middle Front  "- -"
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);  // Left Out    "/".
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ); // Right Out          "\".
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 1, 0, 0, 0, spawnZ + 120);              // Middle         "."
        SpawnAcross(0, 2, 240, 0, -120, spawnZ);   // Middle Front  "- -"
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);  // Left Out    "/".
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ); // Right Out          "\".
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 1, 0, 0, 0, spawnZ + 120);              // Middle         "."
        SpawnAcross(0, 2, 240, 0, -120, spawnZ);   // Middle Front  "- -"
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 3, 120, 120, spawnXMin, spawnZ);  // Left Out    "/".
        SpawnAcross(0, 3, -120, 120, spawnXMax, spawnZ); // Right Out          "\".
        yield return new WaitForSeconds(.5f);
        SpawnAcross(0, 1, 0, 0, 0, spawnZ + 120);              // Middle         "."
        SpawnAcross(0, 2, 240, 0, -120, spawnZ);   // Middle Front  "- -"

        
        StartCoroutine(SpawnLoop(0,.2f, 150, 1));

        yield return new WaitForSeconds(8f);
        
        /*Spawn Green Waves*/
        
        StartCoroutine(SpawnLoop(1, 3f, 3, 1));

        yield return new WaitForSeconds(8f);
        StartCoroutine(SpawnLoop(1, 3f, 4, 2));
        yield return new WaitForSeconds(8f);
        StartCoroutine(SpawnLoop(1, 3f, 6, 3));
        

        yield return new WaitForSeconds(22f);
        SpawnAcross(2, 1, 0, 0, 0, 1100);

        yield return new WaitForSeconds(4f);
        SpawnAcross(2, 2, 700, 0, -350, 1200);
        yield return new WaitForSeconds(8f);
        StartCoroutine(SpawnLoop(2, 8f, 200, 1));

        SpawnAcross(3, 1, 0, 0, 0, 1800);
        yield return new WaitForSeconds(5f);
        SpawnAcross(3, 2, 400, 0, -200, 1900);
        yield return new WaitForSeconds(4f);
        
        StartCoroutine(SpawnLoop(3, 5f, 8, 1));
        StartCoroutine(SpawnLoop(1, 1.5f, 10, 1));
        yield return new WaitForSeconds(20f);
        StartCoroutine(SpawnLoop(0, .5f, 5, 1));
        yield return new WaitForSeconds(4f);
        StartCoroutine(SpawnLoop(0, .5f, 5, 2));
        yield return new WaitForSeconds(4f);
        StartCoroutine(SpawnLoop(0, .5f, 20, 3));
        yield return new WaitForSeconds(16f);

        //SpawnAcross(4, 1, 0, 0, 0, 1334);
        yield return new WaitForSeconds(13f);

        SpawnAcross(0, 2, 240, 0, -120, spawnZ);         // Middle        "- -"
        SpawnAcross(0, 1, 0, 0, 0, spawnZ - 120);        // Middle Front   "."
        yield return new WaitForSeconds(2f);

        SpawnAcross(0, 2, 240, 0, -120, spawnZ);         // Middle        "- -"
        SpawnAcross(0, 1, 0, 0, 0, spawnZ - 120);        // Middle Front   "."
        yield return new WaitForSeconds(2f);
        SpawnAcross(0, 2, 240, 0, -120, spawnZ);         // Middle        "- -"
        SpawnAcross(0, 1, 0, 0, 0, spawnZ - 120);        // Middle Front   "."
        yield return new WaitForSeconds(6f);

        SpawnAcross(2, 2, 0, 0, -400, 1050);
        SpawnAcross(2, 2, 0, 0, 400, 1050);

        yield return new WaitForSeconds(22f);
        SpawnAcross(1, 2, 600, 0, -500, 300);
        yield return new WaitForSeconds(18f);
        SpawnAcross(2, 2, 0, 0, -400, 1050);
        SpawnAcross(2, 2, 0, 0, 400, 1050);


    }


    void SpawnAcross(int enemy, int numAcross, float spacingX, float spacingZ, float spawnXStart, float spawnZStart)
    {
        float spawnXCur = spawnXStart;
        float spawnZCur = spawnZStart;

        for (int i = 0; i < numAcross; i++)
        {
            Instantiate(enemies[enemy], new Vector3(spawnXCur, spawnY, spawnZCur), enemies[enemy].transform.rotation);
            spawnXCur += spacingX;
            spawnZCur += spacingZ;
        }
    }

    IEnumerator SpawnLoop(int enemy, float frequency, float numEnemies, float consecEnemies)
    {
        float mySpawnZ = spawnZ;
        float mySpawnY = spawnY;
        float mySpawnXMin = spawnXMin;
        float mySpawnXMax = spawnXMax;

        if(enemy == 0)
        {
            for (int i = 0; i < consecEnemies; i++)
            {
                mySpawnXMax -= 200;
            }
        }

        if (enemy == 1)
        {
            mySpawnY = 0;
            mySpawnXMin = -650;
            mySpawnXMax = 320;
            for(int i=0; i < consecEnemies; i++)
            {
                mySpawnXMax -= 200;
            }
        }

        if (enemy == 2)
        {
            mySpawnY = 0;
            mySpawnXMin = -380;
            mySpawnXMax = 300;
        }
        if (enemy == 3)
        {
            mySpawnY = 0;
            mySpawnXMin = -450;
            mySpawnXMax = 375;
        }

        float tempSpawnX = mySpawnXMin;

        for (int i=0; i<numEnemies; i++)
        {
            if (enemy == 1)
                mySpawnZ = Random.Range(100, 700);
            else if (enemy == 2)
                mySpawnZ = Random.Range(1100, 1500);
            else if(enemy == 3)
                mySpawnZ = Random.Range(1620, 2094);

            //int randEnemy = (int)Random.Range(0, enemies.Length);
            tempSpawnX = Random.Range(mySpawnXMin, mySpawnXMax);
            for (int e=0; e < consecEnemies; e++)
            {
                Instantiate(enemies[enemy], new Vector3(tempSpawnX, mySpawnY, mySpawnZ), enemies[enemy].transform.rotation);
                tempSpawnX += 200;
            }
            
            yield return new WaitForSeconds(frequency);
        }
        
    }
}
