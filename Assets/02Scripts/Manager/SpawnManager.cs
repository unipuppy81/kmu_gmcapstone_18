using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class SpawnManager : MonoBehaviour
{
    public ObjectManager objectManager;

    public bool enabledSpawn = false;
    public GameObject Box;
    public GameObject sBoss;
    public GameObject Boss;

    public string Enemy;
    public string bEnemy;
   


    

    public TextMeshProUGUI textTimer;
    Transform player;
    Transform bossSpawnPos;

    public Vector3 spawnPos;

    public float spawnTime = 20.0f;
    public float mbspawnTime = 10.0f;
    public float timeAfterSpawn;


    string Enemy1 = "enemyA";
    string Enemy2 = "enemyB";
    // stage 1 ∏  ªÁ¿Ã¡Ó  x -29.7~28.95 , y -29.3~29.3
   
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Enemy = Enemy1;
        bEnemy = Enemy2;

    }

    void Start()
    {
        GameManager gameManager = gameObject.GetComponent<GameManager>();

        timeAfterSpawn = 0;
        spawnPos = player.position;
        spawnPos.y += 5f;

        //InvokeRepeating("SpawnBox", 3, 1f);
        InvokeRepeating("SpawnEnemy", 3, 1f);      
        InvokeRepeating("SpawnbEnemy", 3, 10f);
    }

    void Update()
    {
        SpawnBoss();
    }

    void SpawnBoss()
    {
        timeAfterSpawn += Time.deltaTime;


        if (timeAfterSpawn >= mbspawnTime)
        {
            Instantiate(sBoss, spawnPos, sBoss.transform.rotation);
            mbspawnTime = 10000000000000f;
        }

        if (timeAfterSpawn >= spawnTime)
        {
            Instantiate(Boss, spawnPos, Boss.transform.rotation);
            timeAfterSpawn = 0f;
            spawnTime = 10000000000000f;
        }
    }

    void SpawnEnemy()
    {
        float spawnPosx1 = player.position.x + 8f;
        float spawnPosy1 = player.position.y + 8f;

        float spawnPosx2 = player.position.x - 8f;
        float spawnPosy2 = player.position.y - 8f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        if (randomX >= -29.7f && randomX <= 28.95f && randomY >= -29.3f && randomY <= 29.3f)
        {
            if (enabledSpawn)
            {
                GameObject enemy = objectManager.MakeObj(Enemy);
                enemy.transform.position = new Vector3(randomX, randomY, 0f);
            }
        }
        else
        {
            if (enabledSpawn)
            {
                GameObject enemy = objectManager.MakeObj(Enemy);
                enemy.transform.position = new Vector3(0f, 0f, 0f);

                //GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
    }

    void SpawnbEnemy()
    {
        float spawnPosx1 = player.position.x + 8f;
        float spawnPosy1 = player.position.y + 8f;

        float spawnPosx2 = player.position.x - 8f;
        float spawnPosy2 = player.position.y - 8f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        if (randomX >= -29.7f && randomX <= 28.95f && randomY >= -29.3f && randomY <= 29.3f)
        {
            if (enabledSpawn)
            {
                GameObject benemy = objectManager.MakeObj(bEnemy);
                benemy.transform.position = new Vector3(randomX, randomY, 0f);
            }
        }
        else
        {
            if (enabledSpawn)
            {
                GameObject benemy = objectManager.MakeObj(bEnemy);
                benemy.transform.position = new Vector3(0f, 0f, 0f);
            }
        }
    }

    void SpawnBox()
    {
        //UnityEngine.Debug.Log("SB");
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
