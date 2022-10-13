using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public bool enabledSpawn = false;
    public GameObject Enemy;
    public GameObject Box;
    public GameObject Player;

    Transform player;
    
    // stage 1 ∏  ªÁ¿Ã¡Ó  x -29.7~28.95 , y -29.3~29.3

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

    void SpawnEnemy()
    {
        float spawnPosx1 = player.position.x + 8f;
        float spawnPosy1 = player.position.y + 8f;

        float spawnPosx2 = player.position.x - 8f;
        float spawnPosy2 = player.position.y - 8f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        if(randomX >= -29.7f && randomX <= 28.95f && randomY >= -29.3f && randomY <= 29.3f) { 
            if (enabledSpawn)
            {
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (enabledSpawn)
            {
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
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
