using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Player : MonoBehaviour
{ 
    //layer 사용시 필요
    [SerializeField] float searchRadius = 0f;
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float fireRate = 0f;
    float currentFireRate;

    public Transform hit_target = null;  // 최종타겟 임시시정

    public GameObject bulletObjA;

    public int playerSpeed = 3;
    public float bulletSpeed = 2f;
    public float bulletDamage = 1f;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        currentFireRate = fireRate; 
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
    }

    void Update()
    { 
        Playermove();
    }

    void Playermove() 
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }
    
    void SearchEnemy()                        
    {
        // OverlapCircleAll = 일정한 범위 내의 특정 layer 찾아줌
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask); 
        Transform p_shortestTarget = null;

        if(colls.Length > 0)    // 배열 크기 0보다 크다 : 범위 내에 적이 있다.
        {
            float p_shortestDistance = Mathf.Infinity;

            UnityEngine.Debug.Log("Length > 0");

            foreach (Collider2D p_colTarget in colls)
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - p_colTarget.transform.position);
                if(p_shortestDistance > t_distance)
                {
                    p_shortestDistance = t_distance;
                    p_shortestTarget = p_colTarget.transform;
                }
            }
            // 아래 4줄 : 적 자동 조준 코드
            Vector3 fire = p_shortestTarget.position - transform.position;
            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(fire * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            // 배열 크기 0보다 작다 : 적이 주변에 감지되지 않는다.
            UnityEngine.Debug.Log("Length < 0");
        }
        hit_target = p_shortestTarget;
    }
}
