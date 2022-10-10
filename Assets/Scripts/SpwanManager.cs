using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    public bool enabledSpawn = false;
    public GameObject Enemy;
    public GameObject Box;
 
  

    Vector3 PlayerPos;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 1f);
        
        //InvokeRepeating("SpwanBox", 3, 10f);
        // 코루틴 쓰려했는데 어려움 고쳐봐야됨
    
    }

    void Update()
    {

    }

    void SpawnEnemy()
    {
      //  spawnSpot = GameObject.FindWithTag("Player");
      //  PlayerPos = spawnSpot.transform;

        float spawnPosx = PlayerPos.x + 8f;
        float spawnPosy = PlayerPos.y + 8f;

        float randomX = UnityEngine.Random.Range(-spawnPosx, spawnPosx);
        float randomY = UnityEngine.Random.Range(-spawnPosy, spawnPosy);

        if (enabledSpawn)
        {
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        }
    }

    void SpawnBox()
    {
        float BoxPosx = 8f;
        float BoxPosy = 8f;

        float brandomX = UnityEngine.Random.Range(-BoxPosx, BoxPosx);
        float brandomY = UnityEngine.Random.Range(-BoxPosy, BoxPosy);

        if (enabledSpawn)
        {
            GameObject box = (GameObject)Instantiate(Box, new Vector3(brandomX, brandomY, 0f), Quaternion.identity);
        }
    }
}
