using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //public Rigidbody boss;

    Transform target;


    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        //Move1();
        StartCoroutine(Move());
    }

    void Update()
    {
        //Move1();
    }

    void Skill1()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 3f * Time.deltaTime);
    }


    IEnumerator Move()
    {
        //boss = GetComponent<Rigidbody>();

        while (true)
        {
            //float dir1 = UnityEngine.Random.Range(-2f, 2f);
            //float dir2 = UnityEngine.Random.Range(-2f, 2f);

            float dir1 = 10f * Time.deltaTime;
            float dir2 = 10f * Time.deltaTime;

            Vector3 a = new Vector3(dir1, dir2, 0);

            yield return new WaitForSeconds(2);
            transform.Translate(a);
        }
    }

    void Move1()
    {
        float dir1 = 0.1f * Time.deltaTime;
        float dir2 = 0.1f * Time.deltaTime;

        Vector3 a = new Vector3(dir1, dir2, 0);
        transform.Translate(a);
    }
}
