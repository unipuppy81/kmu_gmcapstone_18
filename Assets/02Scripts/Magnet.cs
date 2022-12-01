using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Magnet : MonoBehaviour
{
    Player player;
    public GameObject ex;

    public bool hasTarget = false;
    Vector3 targetPosition;

    public float magnetStrength = 1f; // �ڼ� ����
    public float distanceStretch = 3f; // �Ÿ��� ���� ����
    public int magnetDirection = 1;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    private void Start()
    {
       // Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        targetPosition = player.transform.position;

        // ���� �༭ �ڼ� ������ ������ �ڼ� �ߵ��ǰ� �Ұ���
        if (player.isMagnet == true) { 
           // Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
        }
        /*if (hasTarget)
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.0001f);

            Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();

            Vector2 targetDirection = (player.transform.position - transform.position).normalized; // �÷��̾�� ���ϴ� ����
            float distance = Vector2.Distance(player.transform.position, transform.position); // �÷��̾�� EX�� �Ÿ�
            float magnetDistanceStr = (distanceStretch / distance) * magnetStrength; // �Ÿ��� ���� ���� �޶�� �ϹǷ� �Ÿ��� ����
            rigid.AddForce(magnetDistanceStr * (targetDirection * magnetDirection), ForceMode2D.Force);
            //rigid.AddForce(targetDirection * 0.2f, ForceMode2D.Impulse);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            hasTarget = false;
            Debug.Log("�÷��̾�� �ε���");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "PlayerMg")
        {
            hasTarget = true;
            Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();

            Vector2 targetDirection = (player.transform.position - transform.position).normalized; // �÷��̾�� ���ϴ� ����
            float distance = Vector2.Distance(player.transform.position, transform.position); // �÷��̾�� EX�� �Ÿ�
            float magnetDistanceStr = (distanceStretch / distance) * magnetStrength; // �Ÿ��� ���� ���� �޶�� �ϹǷ� �Ÿ��� ����
            rigid.AddForce(magnetDistanceStr * (targetDirection * magnetDirection), ForceMode2D.Force);
            Debug.Log("�ε���");
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
