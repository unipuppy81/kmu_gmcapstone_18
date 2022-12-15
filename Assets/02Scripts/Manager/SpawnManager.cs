using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject BossWarning;

    public ObjectManager objectManager;
    public GameManager gameManager;

    private Player p;
    private Enemy e;


    public bool enabledSpawn = false;
    public GameObject Box;
    public GameObject sBoss;
    public GameObject Boss;
    public GameObject enemya;

    public GameObject bTop;
    public GameObject bBottom;
    public GameObject bLeft;
    public GameObject bRight;

    public GameObject[] EnemyArray;

    public GameObject bosshpbar;
    public GameObject exbar;


    public string Enemy;
    public string bEnemy;

    public TextMeshProUGUI textTimer;

    public Vector3 spawnPos;
    public Vector3[] pos;


    public float spawnTime;
    public float mbspawnTime;
    public float timeAfterSpawn;
    public float aenemyspawn;
    public float benemyspawn;




    public bool isSpawnTure;

  
    string Enemy1 = "enemyA";
    string Enemy2 = "enemyB";

    float spawnPosx1, spawnPosy1, spawnPosx2, spawnPosy2, canspawnX1, canspawnX2, canspawnY1, canspawnY2, randomX, randomY, timerr;

    


    Transform player;
    Transform bossSpawnPos;


    // stage 1 ∏  ªÁ¿Ã¡Ó  x -29.7~28.95 , y -29.3~29.3
   
    void Awake()
    {
        BossWarning.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        p = GameObject.Find("Player").GetComponent<Player>();

        Enemy = Enemy1;
        bEnemy = Enemy2;

        spawnTime = 180.0f;
        mbspawnTime = 90.0f;

        isSpawnTure = false;
        bosshpbar.SetActive(false);
        exbar.SetActive(true);
    }

    void Start()
    {
        

        gameManager = gameObject.GetComponent<GameManager>();

        timeAfterSpawn = 0;
        spawnPos = player.position;
        spawnPos.y += 5f;

        InvokeRepeating("SpawnBox", 6, 15.0f);
        InvokeRepeating("SpawnEnemy", 6, 0.3f);
        InvokeRepeating("SpawnbEnemy", 6, 15.0f);
        InvokeRepeating("SpawnEnemyRush", 90, 10000f);

        isSpawnTure = false;
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

        if(timeAfterSpawn >= spawnTime - 2.0f)
        {
            StartCoroutine("SpawnBossText");
        }

        if (timeAfterSpawn >= spawnTime)
        {
            enabledSpawn = false;
            EnemyArray = GameObject.FindGameObjectsWithTag("Enemy01");

            for (int i = 0; i < EnemyArray.Length; i++)
            {
                EnemyArray[i].SetActive(false);
            }

            player.position = new Vector3(0, 0, 0);
            bTop.SetActive(true);
            bBottom.SetActive(true);
            bLeft.SetActive(true);
            bRight.SetActive(true);
            bosshpbar.SetActive(true);
            exbar.SetActive(false);
            Instantiate(Boss, spawnPos, Boss.transform.rotation);
            timeAfterSpawn = 0f;

            p.playerright = 5.5f;
            p.playerleft = -5.5f;
            p.playerbottom = -5.5f;
            p.playertop = 5.5f;

            spawnTime = 10000000000000f;
        }
    }
    
    void SpawnEnemy()
    {
        float spawnPosx1 = player.position.x + 8f;
        float spawnPosy1 = player.position.y + 8f;

        float spawnPosx2 = player.position.x - 8f;
        float spawnPosy2 = player.position.y - 8f;

        float canspawnX1 = player.position.x + 3f;
        float canspawnX2 = player.position.x - 3f;

        float canspawnY1 = player.position.y + 3f;
        float canspawnY2 = player.position.y - 3f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);



        if (randomX >= canspawnX2 && randomX <= canspawnX1 && randomY >= canspawnY2 && randomY <= canspawnY1)
        {
            isSpawnTure = false;
        }
        else
            isSpawnTure = true;

        if (isSpawnTure) { 
            if (randomX >= -29.7f && randomX <= 28.95f && randomY >= -29.3f && randomY <= 29.3f){
                     if (enabledSpawn){
                        GameObject enemy = objectManager.MakeObj(Enemy);
                        enemy.transform.position = new Vector3(randomX, randomY, 0f);

                        Enemy enemylogic = enemy.GetComponent<Enemy>();
                        enemylogic.objectManager = objectManager;

                     }
            }
            else{
                if (enabledSpawn){
                    GameObject enemy = objectManager.MakeObj(Enemy);
                    enemy.transform.position = new Vector3(0f, 0f, 0f);

                    Enemy enemylogic = enemy.GetComponent<Enemy>();
                    enemylogic.objectManager = objectManager;

                }
            }
        }
    }

    void SpawnEnemyRush()
    {
        for(int i = 0; i < 200; i++) { 
        float spawnPosx1 = player.position.x + 8f;
        float spawnPosy1 = player.position.y + 8f;

        float spawnPosx2 = player.position.x - 8f;
        float spawnPosy2 = player.position.y - 8f;

        float canspawnX1 = player.position.x + 3f;
        float canspawnX2 = player.position.x - 3f;

        float canspawnY1 = player.position.y + 3f;
        float canspawnY2 = player.position.y - 3f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);



        if (randomX >= canspawnX2 && randomX <= canspawnX1 && randomY >= canspawnY2 && randomY <= canspawnY1)
        {
            isSpawnTure = false;
        }
        else
            isSpawnTure = true;

        if (isSpawnTure)
        {
            if (randomX >= -29.7f && randomX <= 28.95f && randomY >= -29.3f && randomY <= 29.3f)
            {
                if (enabledSpawn)
                {
                    GameObject enemy = objectManager.MakeObj(Enemy);
                    enemy.transform.position = new Vector3(randomX, randomY, 0f);

                    Enemy enemylogic = enemy.GetComponent<Enemy>();
                    enemylogic.objectManager = objectManager;

                }
            }
            else
            {
                if (enabledSpawn)
                {
                    GameObject enemy = objectManager.MakeObj(Enemy);
                    enemy.transform.position = new Vector3(0f, 0f, 0f);

                    Enemy enemylogic = enemy.GetComponent<Enemy>();
                    enemylogic.objectManager = objectManager;

                }
            }
        }
        }
    }

    void SpawnbEnemy()
    {
        float spawnPosx1 = player.position.x + 8f;
        float spawnPosy1 = player.position.y + 8f;

        float spawnPosx2 = player.position.x - 8f;
        float spawnPosy2 = player.position.y - 8f;

        float canspawnX1 = player.position.x + 3f;
        float canspawnX2 = player.position.x - 3f;

        float canspawnY1 = player.position.y + 3f;
        float canspawnY2 = player.position.y - 3f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        if (randomX >= canspawnX2 && randomX <= canspawnX1 && randomY >= canspawnY2 && randomY <= canspawnY1)
        {
            isSpawnTure = false;
        }
        else
            isSpawnTure = true;

        if (isSpawnTure) { 
            if (randomX >= -29.7f && randomX <= 28.95f && randomY >= -29.3f && randomY <= 29.3f){
                if (enabledSpawn){
                    GameObject benemy = objectManager.MakeObj(bEnemy);
                    benemy.transform.position = new Vector3(randomX, randomY, 0f);

                    Enemy enemylogic = benemy.GetComponent<Enemy>();
                    enemylogic.objectManager = objectManager;
                }
            }
            else{
                if (enabledSpawn){
                    GameObject benemy = objectManager.MakeObj(bEnemy);
                    benemy.transform.position = new Vector3(0f, 0f, 0f);

                    Enemy enemylogic = benemy.GetComponent<Enemy>();
                    enemylogic.objectManager = objectManager;
                }
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

    private IEnumerator SpawnBossText()
    {
        BossWarning.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        BossWarning.SetActive(false);
    }
}
