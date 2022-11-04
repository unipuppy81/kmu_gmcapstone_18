using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //layer 사용시 필요
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] LayerMask layerMask2 = 0;
    [SerializeField] float searchRadius = 0f;
    [SerializeField] float fireRate = 0f;

    public ObjectManager objectManager;

    public Transform hit_target = null;  // 최종타겟 임시시정
    //public GameObject bulletObjA;
    public GameObject Bomb;
    public GameObject skillbtn;

    public string bulletObjA;
    string playerbulletA = "bulletPlayerA";

    bool spSkill1Check = true;

    public float playerSpeed = 3f;
    public float maxSpeed = 10f;
    public float playerMaxHp;
    public float playercurHp;
    public float bulletSpeed = 2f;
    public float bulletDamage;
    public float maxShotDelay = 0.2f;
    public float curShotDelay;
    public int playerLevel = 0;

    public Transform cameraTransform;

    float currentFireRate;

    int count = 0;

    Rigidbody2D rigid;

    void Awake()
    {
        bulletDamage = 3.0f;
        bulletObjA = playerbulletA;

        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerMaxHp = 10f;
        playercurHp = 10f;
        currentFireRate = fireRate;
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
    }

    void Update()
    {
        Playermove();
        Reload();
        SpecialSkill1();
        if(playercurHp <= 0)
            Destroy(gameObject);
    }

    void Playermove()
    {
        Vector3 flipMove = Vector3.zero;
        float h = Input.GetAxisRaw("Horizontal");
        if(h < 0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
        else if(h>0)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        float v = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    void SpecialSkill1() // 군인 특수 스킬
    {
        if (Input.GetKeyDown(KeyCode.Space) && spSkill1Check == true)
        {
            GameObject bomb = (GameObject)Instantiate(Bomb, new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z), Quaternion.identity);
            skillbtn.SetActive(false);
            spSkill1Check = false;
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
           
            //  적 자동 조준 코드 & 발사
            Vector3 fire = p_shortestTarget.position - transform.position;
            GameObject bullet = objectManager.MakeObj(bulletObjA);
            bullet.transform.position = transform.position;
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

            playercurHp += 2f;
            if(playercurHp > 10f)
            {
                playercurHp = 10.0f;
            }
        }
        else if (other.gameObject.tag == "itemspeed")
        {
            Destroy(other.gameObject);

            playerSpeed += 0.5f;
        }
        else if(other.gameObject.tag == "Enemy01")
        {
            playercurHp -= 1f;
        }

        else if (other.gameObject.tag == "enemybulletA")
        {
            playercurHp -= 2f;
        }
    }
}
   
