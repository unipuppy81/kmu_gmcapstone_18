using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Magnet : MonoBehaviour, ICollectible
{
    public static event Action onExCollected;
    Rigidbody2D rb;

    public GameObject ex;

    bool hasTarget = false;
    Vector3 targetPosition;

    float moveSpeed = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Rigidbody2D rigid = ex.GetComponent<Rigidbody2D>();

            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            //rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
            rigid.AddForce(targetDirection * 10f, ForceMode2D.Impulse);

            // 플레이어 바운더리 콜라이더에서는 힘만 주기
            // 플레이어 콜라이더에 닿으면 경험치가 사라지도록 만들기
        }
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
        targetPosition = position;
        hasTarget = true;
    }

    public void Collect()
    {
        onExCollected?.Invoke();
    }
}
