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
    //layer ���� �ʿ�
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 0f;

    public ObjectManager objectManager;

    // A = ����, B = ���Ÿ�, C = �߰�����
    public enum Type { A, B, C };
    public Type enemyType;
    public Sprite[] sprites;
    public GameObject EnemyBullet;

    public GameObject sbossEx;

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

    SpriteRenderer spriteRenderer; // �ǰ� �ִϸ��̼�
    Rigidbody2D rigid;
    Transform target;

    void Awake()
    {

        experienceA = exAcheck;
        experienceB = exBcheck;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        switch (enemyType)
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
        // OverlapCircleAll = ������ ���� ���� Ư�� layer ã����
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask);

        foreach (Collider2D p_Target in colls)
        {
            target = p_Target.transform;
        }

        if (curShotDelay < maxShotDelay)
        {
            return;
        }

        // �Ʒ� 4�� : �� �ڵ� ���� �ڵ� & �߻�


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
            //UnityEngine.Debug.Log("Player");
        }
        else if (other.gameObject.tag == "Enemy01")
        {
            //UnityEngine.Debug.Log("Enemy01");
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            onHit(bullet.dmg);
        }
        else if (other.gameObject.tag == "SpecialSkill1")
        {
            SpecialSkill1 specialSkill1 = other.gameObject.GetComponent<SpecialSkill1>();
            onHit(specialSkill1.dmg);
        }
        else if (other.gameObject.CompareTag("Skill")) // ����(�����)
        {
            Skill_Guardian skill_Guardian = other.gameObject.GetComponent<Skill_Guardian>();
            onHit(skill_Guardian.dmg);
        }
        else if (other.gameObject.CompareTag("Skill2")) //EMP�ʵ�(�ڱ���)
        {
            Skill_Magnetic skill_Magnetic = other.gameObject.GetComponent<Skill_Magnetic>();
            onHit(skill_Magnetic.dmg);
        }
    }
}