using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemmagnet : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 1000f;

    public GameObject[] exArray;
    public GameObject[] ex2Array;

    private Player player;

    public GameManager gm;

    Transform target;
    Rigidbody2D rigid;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gm = gameObject.GetComponent<GameManager>();
    }
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            exArray = GameObject.FindGameObjectsWithTag("Ex");
            ex2Array = GameObject.FindGameObjectsWithTag("Ex2");

            for(int i = 0; i < exArray.Length; i++)
            {
                exArray[i].transform.position = target.position;
                //gm.exManager();
            }


            for (int i = 0; i < ex2Array.Length; i++)
            {
                ex2Array[i].transform.position = target.position;
            }
        }
    }
}
