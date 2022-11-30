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

        // 조건 줘서 자석 아이템 먹으면 자석 발동되게 할거임
        Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();
        targetPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.01f);
        
        //Vector2 targetDirection = (targetPosition - transform.position).normalized;
        //rigid.AddForce(targetDirection * 0.01f, ForceMode2D.Impulse);

        //UnityEngine.Debug.Log(targetPosition);
        // 플레이어 바운더리 콜라이더에서는 힘만 주기
            // 플레이어 콜라이더에 닿으면 경험치가 사라지도록 만들기
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
