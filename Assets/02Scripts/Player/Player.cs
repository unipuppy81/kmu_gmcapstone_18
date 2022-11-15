using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //layer 사용시 필요
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] LayerMask layerMask2 = 0;
    [SerializeField] float searchRadius;
    [SerializeField] float fireRate = 0f;
    [SerializeField] TextMeshProUGUI spcountText;

    public ObjectManager objectManager;
    public Enemy enemy;

    public Transform hit_target = null;  // 최종타겟 임시시정
    //public GameObject bulletObjA;
    public GameObject Bomb;
    public GameObject skillbtn;
    public GameObject gameoverPannel;
    public GameObject gameclearPannel;
    public GameObject BasketBall;

    public string bulletObjA;
    string playerbulletA = "bulletPlayerA";



    bool spSkill1Check = true;

    public float playerSpeed = 3f;
    public float maxSpeed = 10f;
    public float playerMaxHp;
    public float playercurHp;
    public float bulletSpeed;
    public float bulletDamage;
    public float maxShotDelay = 0.2f;
    public float curShotDelay;
    public int playerLevel = 0;
    public int specialSkill = 0;
    public float spawntime;

    public float playertop;
    public float playerbottom;
    public float playerleft;
    public float playerright;

    public Vector3 basketfire;
    public Vector2 basketfire2d;

    public Transform cameraTransform;
    float currentFireRate;

    int count = 0;

    Rigidbody2D rigid;

    void Awake()
    {
        playertop = 29.3f;
        playerbottom = -29.3f;
        playerleft = -29.7f;
        playerright = 28.95f;
        searchRadius = 7f;
        bulletSpeed = 4f;
        specialSkill = 1;
        bulletDamage = 3.0f;
        bulletObjA = playerbulletA;
        playerMaxHp = 30f;
        playercurHp = 30f;
        rigid = GetComponent<Rigidbody2D>();
        spawntime = 0.5f;
    }

    void Start()
    {
        currentFireRate = fireRate;
        InvokeRepeating("SearchEnemy", 0f, spawntime);
    }

    void Update()
    {
        spcount();
        Playermove();
        Reload();
        SpecialSkill1();
        specialSkillbtn();
        basketball();
    }

    void basketball()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            basketballscript();
        }
    }

    void basketballscript()
    {
        UnityEngine.Debug.Log("ABC");
    
        basketfire = new Vector3(transform.position.x + 5f, transform.position.y + 5f, transform.position.z + 5f);
        GameObject ball = Instantiate(BasketBall, transform.position, transform.rotation);
        Rigidbody2D rigid = ball.GetComponent<Rigidbody2D>();

        basketfire2d = new Vector2(basketfire.x, basketfire.y).normalized;


        //rigid.AddForce(basketfire, ForceMode2D.Impulse);
        rigid.AddForce(basketfire2d * 10f,ForceMode2D.Impulse);
    }

    void spcount()
    {
        spcountText.text = String.Format("Count : {0:D1}", specialSkill);
    }

    void Playermove()
    {
        Vector3 flipMove = Vector3.zero;
        float h = Input.GetAxisRaw("Horizontal");
        if(h < 0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-0.04f, 0.04f, 0.0f);
        }
        else if(h > 0)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(0.04f, 0.04f, 0.0f);
        }

        float v = Input.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;

        if(pos.x > playerright)
        {
            h = 0;
            pos.x = playerright;
        }
        else if(pos.x < playerleft)
        {
            h = 0;
            pos.x = playerleft;
        }

        if (pos.y > playertop)
        {
            v = 0;
            pos.y = playertop;
        }
        else if (pos.y < playerbottom)
        {
            v = 0;
            pos.y = playerbottom;
        }

        transform.position = pos;


        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    void SpecialSkill1() // 군인 특수 스킬
    {
         if (Input.GetKeyDown(KeyCode.Space) )
         {
              if (specialSkill != 0)
              {
                  specialSkill -= 1;
                  GameObject bomb = (GameObject)Instantiate(Bomb, new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z), Quaternion.identity);
                  skillbtn.SetActive(true);

                  //spSkill1Check = false; && spSkill1Check == true
              }
              //else if(specialSkill > 0)
              //{

              //   skillbtn.SetActive(false);
              //}
         }
    }

    void specialSkillbtn()
    {
        if(specialSkill == 0)
        {
            skillbtn.SetActive(false);
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

            float angle2 = Vector3.SignedAngle(transform.up, fire, transform.forward);

            bullet.transform.localEulerAngles = new Vector3(0, 0, angle2);
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

    void OnTriggerStay2D(Collider2D other)
    {
        if (playercurHp <= 0)
        {
            Time.timeScale = 0;
            gameoverPannel.SetActive(true);
        }

        if(Boss.bossHealth <= 0)
        {
            Time.timeScale = 0;
            gameclearPannel.SetActive(true);
        }
    }
}
   
