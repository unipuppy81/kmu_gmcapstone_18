using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;

    public GameObject exAPrefab;
    public GameObject exBPrefab;

    public GameObject bulletPlayerAPrefab;
    public GameObject bulletEnemyAPrefab;

    public GameObject WallPrefab;

    public Transform player;

    GameObject[] enemyA;
    GameObject[] enemyB;

    GameObject[] exA;
    GameObject[] exB;

    GameObject[] bulletPlayerA;

    GameObject[] bulletEnemyA;
    GameObject[] Wall;

    GameObject[] targetPool;



    void Awake() // 로딩시간에 오브젝트 풀 생성
    {
        enemyA = new GameObject[400];
        enemyB = new GameObject[30];

        exA = new GameObject[1200];
        exB = new GameObject[300];

        bulletPlayerA = new GameObject[30];

        bulletEnemyA = new GameObject[30];

        Wall = new GameObject[100];
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

        // #3. Ex
        for (int index = 0; index < exA.Length; index++)
        {
            exA[index] = Instantiate(exAPrefab);
            exA[index].SetActive(false);
        }

        for (int index = 0; index < exB.Length; index++)
        {
            exB[index] = Instantiate(exBPrefab);
            exB[index].SetActive(false);
        }

        // #4. Boss Weapon
        for (int index = 0; index < Wall.Length; index++)
        {
            Wall[index] = Instantiate(WallPrefab);
            Wall[index].SetActive(false);
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
            case "exA":
                targetPool = exA;

                break;
            case "exB":
                targetPool = exB;
                break;

            case "wall":
                targetPool = Wall;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++){
            if (!targetPool[index].activeSelf){
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }
}
