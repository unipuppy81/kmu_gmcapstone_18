using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //layer 사용시 필요
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 0f;
    [SerializeField] float fireRate = 0f;

    public Transform hit_target = null;  // 최종타겟 임시시정
    public GameObject bulletObjA;
    public GameObject Bomb;

    bool check = true;

    public float playerSpeed = 3;
    public float playerHp = 10f;
    public float bulletSpeed = 2f;
    public float bulletDamage = 2f;
    public float maxShotDelay = 0.2f;
    public float curShotDelay;

    public Transform cameraTransform;

    float currentFireRate;

    int count = 0;

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
        Reload();
        SpecialSkill1();
    }

    void Playermove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    void SpecialSkill1() // 군인 특수 스킬
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bomb = (GameObject)Instantiate(Bomb, new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z), Quaternion.identity);
        }
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void SearchEnemy()
    {
        // OverlapCircleAll = 일정한 범위 내의 특정 layer 찾아줌
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask);
        Transform p_shortestTarget = null;

        if (colls.Length > 0)    // 배열 크기 0보다 크다 : 범위 내에 적이 있다.
        {
            float p_shortestDistance = Mathf.Infinity;
            foreach (Collider2D p_colTarget in colls)
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - p_colTarget.transform.position);
                if (p_shortestDistance > t_distance)
                {
                    p_shortestDistance = t_distance;
                    p_shortestTarget = p_colTarget.transform;
                }
            }

            if (curShotDelay < maxShotDelay)
            {
                return;
            }
            // 아래 4줄 : 적 자동 조준 코드 & 발사
            Vector3 fire = p_shortestTarget.position - transform.position;
            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(fire * bulletSpeed, ForceMode2D.Impulse);

            curShotDelay = 0;
        }
        else
        {
            // 배열 크기 0보다 작다 : 적이 주변에 감지되지 않는다.
        }
        hit_target = p_shortestTarget;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "itemhp")
        {
            Destroy(other.gameObject);

            playerHp += 2f;
        }
        else if (other.gameObject.tag == "itemspeed")
        {
            Destroy(other.gameObject);

            playerSpeed += 0.5f;
        }
    }
}
   
