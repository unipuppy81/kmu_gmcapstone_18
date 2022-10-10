using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    public bool enabledSpawn = false;
    public GameObject Enemy;
  

    Vector3 PlayerPos;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 0.3f);
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
}
