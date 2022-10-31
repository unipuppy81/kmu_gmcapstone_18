using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Skill_Guardian : MonoBehaviour
{
    WeaponButton weaponButton;

    public GameObject[] guardians;
    public int hasGuardians = 0;

    public int dmg = 3;

    public float time = 360;

    //public Player player;

    public Transform target;
    public float orbitSpeed;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        weaponButton = GetComponent<WeaponButton>();
    }

    // Update is called once per frame
    void Update()
    {
        //searchEnemy1();
        transform.position = target.position + offset;
        transform.RotateAround(target.position, Vector3.forward, orbitSpeed * Time.deltaTime);

        offset = transform.position - target.position;
    }

    void searchEnemy1()
    {
        GameObject[] enemy1 = GameObject.FindGameObjectsWithTag("Enemy01");

        for (int i = 0; i < enemy1.Length; i++)
        {
            // Destroy(enemy1[i]);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Box")
        {
            //Destroy(gameObject);
        }
    }

    /*void skillTime(float playTime)
    {
        int loopNum = 0;
        loopNum++;
        while (playTime > 0)
        {
            if (playTime == 360 || playTime % 5 != 0)
            {
                guardians[0].SetActive(true);
                guardians[1].SetActive(true);
                guardians[2].SetActive(true);
                guardians[3].SetActive(true);
            }
            else if (playTime != 360 && playTime % 5 == 0)
            {
                guardians[0].SetActive(false);
                guardians[1].SetActive(false);
                guardians[2].SetActive(false);
                guardians[3].SetActive(false);
            }
            playTime -= Time.deltaTime;
            if (playTime <= 0) break;
            if (loopNum > 10000)
                throw new Exception("Infinite Loop");
        }
    }*/
}
