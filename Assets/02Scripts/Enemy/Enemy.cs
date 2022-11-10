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

    public GameObject hudDamageText;

    private Player player2;
    public ObjectManager objectManager;
    public GameManager gameManger;

    // A = 근접, B = 원거리, C = 중간보스
    public enum Type { A, B, C };
    public Type enemyType;
    public Sprite[] sprites;
    public GameObject EnemyBullet;

    public GameObject sbossEx;

    public float enemyHealth;
    public float enemySpeed;
    public float enemyDamage;
    public float bulletenemyDamage;
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
    Transform target;

    void Awake()
    {
        experienceA = exAcheck;
        experienceB = exBcheck;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player2 = GameObject.Find("Player").GetComponent<Player>();
    }

    void Start()
    {
        switch (enemyType)
        {
            case Type.A:
                enemyHealth = 4f;
                enemySpeed = 2.0f;
                enemyDamage = 2f;

                break;
            case Type.B:
                enemyHealth = 3f;
                enemySpeed = 1.8f;
                bulletenemyDamage = 4f;
                enemyDamage = 1f;
                searchRadius = 5f;
                bulletSpeed = 1.0f;
                InvokeRepeating("SearchPlayer", 0f, 0.5f);
                break;

            case Type.C:
                enemyHealth = 100f;
                enemySpeed = 3f;
                enemyDamage = 5f;

                break;

        }
    }

    void Update()
    {
        switch (enemyType)
        {
            case Type.A:
                FollowTarget();

                break;
            case Type.B:
                Reload();
                isShooting();
                if (!isShoot)
                {
                    FollowTarget();
                }
                break;

            case Type.C:
                FollowTarget();

                break;
        }
    }

    void durationTime()
    {
        
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

    public void onHit(float dmg)
    {
        enemyHealth -= dmg;
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
            switch (enemyType)
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
                    Instantiate(sbossEx, transform.position, sbossEx.transform.rotation);
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
            switch (enemyType)
            {
                case Type.A:
                    player2.playercurHp -= enemyDamage;

                    break;
                case Type.B:
                    player2.playercurHp -= enemyDamage;

                    break;
                case Type.C:
                    player2.playercurHp -= enemyDamage;
                    break;
            }
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            onHit(bullet.dmg);
            takeDamageText(bullet.dmg);
        }
        else if (other.gameObject.tag == "SpecialSkill1")
        {
            SpecialSkill1 specialSkill1 = other.gameObject.GetComponent<SpecialSkill1>();
            onHit(specialSkill1.dmg);
            takeDamageText(specialSkill1.dmg);
        }
        else if (other.gameObject.CompareTag("Skill")) // 방패(가디언)
        {
            Skill_Guardian skill_Guardian = other.gameObject.GetComponent<Skill_Guardian>();
            onHit(skill_Guardian.dmg);
            takeDamageText(skill_Guardian.dmg);
        }
        else if (other.gameObject.CompareTag("Skill2")) //EMP필드(자기장)
        {
            Skill_Magnetic skill_Magnetic = other.gameObject.GetComponent<Skill_Magnetic>();
            onHit(skill_Magnetic.dmg);
            takeDamageText(skill_Magnetic.dmg);
        }
    }
    void takeDamageText(float damage)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);  // 자기 자신 머리 위에 데미지 표시
        hudText.GetComponent<DamageText>().damage = damage;
    }
}