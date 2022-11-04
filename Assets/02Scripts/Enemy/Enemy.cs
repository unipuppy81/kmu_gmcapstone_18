using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //layer 사용시 필요
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 0f;

    public ObjectManager objectManager;

    // A = 근접, B = 원거리, C = 중간보스
    public enum Type { A, B, C };
    public Type enmeyType;
    public Sprite[] sprites;
    public GameObject EnemyBullet;

    public float enemyHealth;
    public float enemySpeed;
    public float enemyDamage;
    public float maxShotDelay = 3f;
    public float curShotDelay;
    public float bulletSpeed;

    public bool isShoot;

    public string experienceA;
    public string experienceB;

    string exAcheck = "exA";
    string exBcheck = "exB";

    SpriteRenderer spriteRenderer; // 피격 애니메이션
    Rigidbody2D rigid;
    Transform target, exPoint;

    void Awake()
    {
        exPoint = null;

        experienceA = exAcheck;
        experienceB = exBcheck;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        switch (enmeyType)
        {
            case Type.A:
                enemyHealth = 2f;
                enemySpeed = 2f;
                enemyDamage = 2f;

                break;
            case Type.B:
                enemyHealth = 1f;
                enemySpeed = 1.5f;
                enemyDamage = 4f;
                searchRadius = 5f;
                bulletSpeed = 1f;
                InvokeRepeating("SearchPlayer", 0f, 0.5f);
                break;

            case Type.C:
                enemyHealth = 20f;
                enemySpeed = 2f;
                enemyDamage = 3f;

                break;

        }
    }

    void Update()
    {
        switch (enmeyType)
        {
            case Type.A:
                FollowTarget();

                break;
            case Type.B:
                Reload();
                isShooting();
                if (!isShoot) { 
                    FollowTarget();
                }
                break;

            case Type.C:
                FollowTarget();

                break;
        }
        
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void isShooting()
    {
        float dist = Vector3.SqrMagnitude(transform.position - target.transform.position);
        if (dist > searchRadius)
            isShoot = false;
        else
            isShoot = true;

    }
    void FollowTarget()
    {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
    }

    void SearchPlayer()
    {
        // OverlapCircleAll = 일정한 범위 내의 특정 layer 찾아줌
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask);

        foreach (Collider2D p_Target in colls)
        {
            target = p_Target.transform;
        }
        
        if (curShotDelay < maxShotDelay)
        {
            return;
        }

        // 아래 4줄 : 적 자동 조준 코드 & 발사


        Vector3 fire = target.position - transform.position;
        GameObject eBullet = Instantiate(EnemyBullet, transform.position, transform.rotation);
        Rigidbody2D rigid = eBullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(fire * bulletSpeed, ForceMode2D.Impulse);

        curShotDelay = 0;
    }

    void onHit(float dmg)
    {
        enemyHealth -= dmg;
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
            //GameObject exA = objectManager.MakeObj(experienceA);
            //GameObject exB = objectManager.MakeObj(experienceB);
            switch (enmeyType)
            {

                case Type.A:
                    GameObject experiencea = objectManager.MakeObj(experienceA);
                    experiencea.transform.position = transform.position;


                    break;
                case Type.B:
                    GameObject experienceb = objectManager.MakeObj(experienceB);
                    experienceb.transform.position = transform.position;

                    break;
                case Type.C:
                    for (int i = 0; i < 1; i++)
                    {
                        float exspawnx1 = transform.position.x + 2f;
                        float exspawny1 = transform.position.y + 2f;

                        float exspawnx2 = transform.position.x - 2f;
                        float exspawny2 = transform.position.y - 2f;

                        float randomX = UnityEngine.Random.Range(exspawnx1, exspawnx2);
                        float randomY = UnityEngine.Random.Range(exspawny1, exspawny1);

                        UnityEngine.Debug.Log("1");
                          
                        GameObject exA = objectManager.MakeObj(experienceA);

                        //UnityEngine.Debug.Log("2");
                        exA.transform.position = new Vector3(randomX, randomY, 0f);
                        //UnityEngine.Debug.Log("3");
                    }

                    UnityEngine.Debug.Log("4");
                    
                    for (int i = 0; i< 3; i++) {
                        float exspawnx1a = transform.position.x + 2f;
                        float exspawny1a = transform.position.y + 2f;

                        float exspawnx2a = transform.position.x - 2f;
                        float exspawny2a = transform.position.y - 2f;

                        float randomXa = UnityEngine.Random.Range(exspawnx1a, exspawnx2a);
                        float randomYa = UnityEngine.Random.Range(exspawny1a, exspawny2a);
                        UnityEngine.Debug.Log("5");
                        GameObject exB = objectManager.MakeObj(experienceB);
                        UnityEngine.Debug.Log("6");
                        exB.transform.position = new Vector3(randomXa, randomYa, 0f);
                        UnityEngine.Debug.Log("7");
                    }
                    break;
            }
        }  
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //UnityEngine.Debug.Log("Player");
        }
        else if (other.gameObject.tag == "Enemy01")
        {
            //UnityEngine.Debug.Log("Enemy01");
        }
        else if(other.gameObject.tag == "Bullet")
        {
           Bullet bullet = other.gameObject.GetComponent<Bullet>();

            onHit(bullet.dmg);
        }
        else if (other.gameObject.tag == "SpecialSkill1")
        {
            SpecialSkill1 specialSkill1 = other.gameObject.GetComponent<SpecialSkill1>();
            onHit(specialSkill1.dmg);
        }
        else if (other.gameObject.CompareTag("Skill")) // 방패(가디언)
        {
            Skill_Guardian skill_Guardian = other.gameObject.GetComponent<Skill_Guardian>();
            onHit(skill_Guardian.dmg);
        }
        else if (other.gameObject.CompareTag("Skill2")) //EMP필드(자기장)
        {
            Skill_Magnetic skill_Magnetic = other.gameObject.GetComponent<Skill_Magnetic>();

            onHit(skill_Magnetic.dmg);
        }
    }
}