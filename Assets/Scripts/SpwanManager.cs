using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    public bool enabledSpawn = false;
    public GameObject Enemy;
    public GameObject Box;
    public GameObject Player;

    Transform player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        InvokeRepeating("SpawnBox", 3, 1f);
        InvokeRepeating("SpawnEnemy", 3, 1f);   
    }

    void Update()
    {
    }

    void SpawnPos()
    {

    }

    void SpawnEnemy()
    {
        //  spawnSpot = GameObject.FindWithTag("Player");
        //  PlayerPos = spawnSpot.transform;

        float spawnPosx = player.position.x + 8f;
        float spawnPosy = player.position.y + 8f;

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
