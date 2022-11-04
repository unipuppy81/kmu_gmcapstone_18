using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;

    public GameObject bulletPlayerAPrefab;
    public GameObject bulletEnemyAPrefab;


    GameObject[] enemyA;
    GameObject[] enemyB;
    //GameObject[] enemyC;
    //GameObject[] bossEnemy;

    //GameObject[] box;
    //GameObject[] item_bomb;
    //GameObject[] item_hp;
    //GameObject[] item_magnet;
    //GameObject[] item_speed;

    GameObject[] bulletPlayerA;
    //GameObject[] bulletPlayerB;
    GameObject[] bulletEnemyA;


    GameObject[] targetPool;

    void Awake() // 로딩시간에 오브젝트 풀 생성
    {
        enemyA = new GameObject[100];
        enemyB = new GameObject[20];
        //enemyC = new GameObject[3];
        //bossEnemy = new GameObject[2];

        //box = new GameObject[20];
        //item_bomb = new GameObject[20];
        //item_hp = new GameObject[20];
        //item_magnet = new GameObject[20];
        //item_speed = new GameObject[20];

        bulletPlayerA = new GameObject[20];
        //bulletPlayerB = new GameObject[10];
        bulletEnemyA = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        // #1. enemy
        for(int index = 0; index < enemyA.Length; index++)
        {
            enemyA[index] = Instantiate(enemyAPrefab);
            enemyA[index].SetActive(false);
        }

        for (int index = 0; index < enemyB.Length; index++)
        {
            enemyB[index] = Instantiate(enemyBPrefab);
            enemyB[index].SetActive(false);
        }

        // #2. bullet
        for (int index = 0; index < bulletPlayerA.Length; index++)
        {
            bulletPlayerA[index] = Instantiate(bulletPlayerAPrefab);
            bulletPlayerA[index].SetActive(false);
        }

        for (int index = 0; index < bulletEnemyA.Length; index++)
        {
            bulletEnemyA[index] = Instantiate(bulletEnemyAPrefab);
            bulletEnemyA[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "enemyA":
                targetPool = enemyA;
                break;

            case "enemyB":
                targetPool = enemyB;
                break;

            case "bulletPlayerA":
                targetPool = bulletPlayerA;
                break;

            case "bulletEnemyA":
                targetPool = bulletEnemyA;
                break;
        }

        for (int index = 0; index < enemyA.Length; index++){
            if (!targetPool[index].activeSelf){
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }
}
