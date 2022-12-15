using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    Player player;
    public GameObject ex;

    public bool hasTarget = false;
    Vector3 targetPosition;

    public float magnetStrength = 15f; // �ڼ� ����
    public float distanceStretch = 10f; // �Ÿ��� ���� ����
    public int magnetDirection = 1;

    Rigidbody2D rigid;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rigid = ex.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       
    }

    private void FixedUpdate()
    {
        targetPosition = player.transform.position;

        // ���� �༭ �ڼ� ������ ������ �ڼ� �ߵ��ǰ� �Ұ���
        if (player.isMagnet == true) { 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.15f);
        }

        if (hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.15f);
        }

    }
    private void Update()
    {
        transform.Rotate(new Vector3(0,10f,0) * 40f *Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            hasTarget = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "PlayerMg")
        {
            hasTarget = true;
        }
    }
}
