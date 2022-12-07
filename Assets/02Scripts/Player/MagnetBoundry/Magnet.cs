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

    public float magnetStrength = 2f; // 자석 세기
    public float distanceStretch = 4f; // 거리에 따른 세기
    public int magnetDirection = 1;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
       
    }

    private void FixedUpdate()
    {
        targetPosition = player.transform.position;

        // 조건 줘서 자석 아이템 먹으면 자석 발동되게 할거임
        if (player.isMagnet == true) { 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
        }
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
            Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();

            Vector2 targetDirection = (player.transform.position - transform.position).normalized; // 플레이어로 향하는 벡터
            float distance = Vector2.Distance(player.transform.position, transform.position); // 플레이어와 EX의 거리
            float magnetDistanceStr = (distanceStretch / distance) * magnetStrength; // 거리에 따른 힘이 달라야 하므로 거리로 나눔
            rigid.AddForce(magnetDistanceStr * (targetDirection * magnetDirection), ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerMg")
        {
            hasTarget = false;
        }
    }
}
