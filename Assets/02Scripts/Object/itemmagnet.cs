using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemmagnet : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 1000f;

    private Player player;

    Transform target;
    Rigidbody2D rigid;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);


            Collider2D[] colls = Physics2D.OverlapCircleAll(target.position, searchRadius, layerMask);

            foreach (Collider2D p_Target in colls)
            {
                p_Target.transform.position = target.position;
            }
        }
    }
}
