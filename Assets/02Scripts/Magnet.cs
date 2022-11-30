using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Magnet : MonoBehaviour, ICollectible
{
    public static event Action onExCollected;
    Rigidbody2D rb;
    Player player;
    public GameObject ex;

    public bool hasTarget = false;
    Vector3 targetPosition;
   

    float moveSpeed = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        //targetPosition = player.transform.position;
    }

    private void FixedUpdate()
    {

        // ���� �༭ �ڼ� ������ ������ �ڼ� �ߵ��ǰ� �Ұ���
        Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();
        targetPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.01f);
        
        //Vector2 targetDirection = (targetPosition - transform.position).normalized;
        //rigid.AddForce(targetDirection * 0.01f, ForceMode2D.Impulse);

        //UnityEngine.Debug.Log(targetPosition);
        // �÷��̾� �ٿ���� �ݶ��̴������� ���� �ֱ�
            // �÷��̾� �ݶ��̴��� ������ ����ġ�� ��������� �����
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            
            //onExCollected?.Invoke();
            Collect();
            //gameObject.SetActive(false);
        }
    }

    public void setTarget(Vector3 position)
    {
        //targetPosition = position;
        hasTarget = true;
    }

    public void Collect()
    {
        onExCollected?.Invoke();
    }
}
