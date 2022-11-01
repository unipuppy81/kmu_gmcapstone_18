using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class SpawnManager : MonoBehaviour
{
    public bool enabledSpawn = false;
    public GameObject Enemy;
    public GameObject Box;
    public GameObject sbEnemy;
    public GameObject Boss;
    public TextMeshProUGUI textTimer;
    Transform player;
    
    // stage 1 ∏  ªÁ¿Ã¡Ó  x -29.7~28.95 , y -29.3~29.3

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        GameManager gameManager = gameObject.GetComponent<GameManager>();
        //InvokeRepeating("SpawnBox", 3, 1f);
        InvokeRepeating("SpawnEnemy", 3, 1f);
        /*
        if(gameManager._mina == 6)
        {
            SpawnsBoss();
        }
        */
       
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

    void SpawnsBoss()
    {
        float spawnsbPosx1 = player.position.x + 2f;
        float spawnsbPosy1 = player.position.y + 2f;

        float spawnsbPosx2 = player.position.x - 2f;
        float spawnsbPosy2 = player.position.y - 2f;

        float sbrandomX = UnityEngine.Random.Range(spawnsbPosx1, spawnsbPosx2);
        float sbrandomY = UnityEngine.Random.Range(spawnsbPosy1, spawnsbPosy2);

        if (sbrandomX >= -29.7f && sbrandomX <= 28.95f && sbrandomY >= -29.3f && sbrandomY <= 29.3f)
        {
            if (enabledSpawn)
            {
                GameObject sbenemy = (GameObject)Instantiate(sbEnemy, new Vector3(sbrandomX, sbrandomY, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (enabledSpawn)
            {
                GameObject sbenemy = (GameObject)Instantiate(sbEnemy, new Vector3(player.position.x, player.position.y, 0f), Quaternion.identity);
            }
        }
    }
}
