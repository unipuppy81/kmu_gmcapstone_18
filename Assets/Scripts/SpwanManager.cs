using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    public bool enabledSpawn = false;
    public GameObject Enemy;

    Vector3 PlayerPos;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 1);
    }

    void Update()
    {
        PlayerPos = transform.position;
    }

    void SpawnEnemy()
    {
        

        float spawnPosx = PlayerPos.x + 8f;
        float spawnPosy = PlayerPos.y + 8f;

        float randomX = Random.Range(-spawnPosx, spawnPosx);
        float randomY = Random.Range(-spawnPosy, spawnPosy);

        if (enabledSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        }
    }
}
