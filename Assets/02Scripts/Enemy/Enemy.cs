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

    public GameObject hudDamageText;

    private Player player2;
    public ObjectManager objectManager;
    public GameManager gameManger;

    Skill_Magnetic skill_magnetic;

    // A = ����, B = ���Ÿ�, C = �߰�����
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
    public float enemyaMaxHealth;
    public float enemybMaxHealth;

    public bool isHit;
    float hitTime;

    public bool isShoot;
    public bool isAlive;

    public string experienceA;
    public string experienceB;

    string exAcheck = "exA";
    string exBcheck = "exB";

    SpriteRenderer spriteRenderer; // �ǰ� �ִϸ��̼�
    Rigidbody2D rigid;
    Transform target;
    Animator anim;
    float t;

    void Awake()
    {
        isAlive = true;

        experienceA = exAcheck;
        experienceB = exBcheck;

        enemyaMaxHealth = 4f;
        enemybMaxHealth = 3f;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player2 = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        //skill_magnetic = new Skill_Magnetic();
        //skill_magnetic = GetComponent<Skill_Magnetic>();
        skill_magnetic = GameObject.Find("MagneticField").GetComponent<Skill_Magnetic>();
    }

    void OnEnable() // Ȱ��ȭ�ɶ� �����
    {
        switch (enemyType)
        {
            case Type.A:
                isAlive= true;
                enemySpeed = 0.75f;
                gameObject.layer = 7;
                if (t >=0 && t <= 45)
                {
                    enemyHealth = 2f;
                }
                else if (t >= 45)
                {
                    enemyHealth = 8f;
                }


                break;

            case Type.B:
                isAlive = true;
                enemySpeed = 0.55f;
                gameObject.layer = 7;
                if (t >= 0 && t <= 45)
                {
                    enemyHealth = 2f;
                }
                else if (t >= 45)
                {
                    enemyHealth = 6f;
                }


                break;
        }
    }

    void Start()
    {
        switch (enemyType)
        {
            case Type.A:

                enemyHealth = 2f;
                    enemySpeed = 0.7f;
                    enemyDamage = 2f;

                break;

            case Type.B:

                enemyHealth = 2f;
                enemySpeed = 0.5f;
                bulletenemyDamage = 4f;
                enemyDamage = 1f;
                searchRadius = 5f;
                bulletSpeed = 7.0f;
                InvokeRepeating("SearchPlayer", 0f, 0.5f);

                break;

            case Type.C:
                enemyHealth = 100f;
                enemySpeed = 0.8f;
                enemyDamage = 5f;

                break;
        }
    }

    void Update()
    {
        t += Time.deltaTime;
        hitTime += Time.deltaTime;
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
        if(isHit)
        {
            if(hitTime >= 0.5f)
            {
                onHit(skill_magnetic.dmg);
                takeDamageText(skill_magnetic.dmg);
                hitTime = 0.0f;
            }
        }
    }

    void UpdateHealth()
    {
        t += Time.deltaTime;
        if(t >= 10.0f)
        {
            enemyaMaxHealth = 10f;
            enemybMaxHealth = 10f;
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

        float spriteflip = target.position.x - transform.position.x;

        if (isAlive)
            spriteRenderer.flipX = spriteflip > 0;
    }

    void SearchPlayer()
    {
        if (player2.playercurHp < 0)
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
        fire = fire.normalized;
        GameObject eBullet = Instantiate(EnemyBullet, transform.position, transform.rotation);
        Rigidbody2D rigid = eBullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(fire * bulletSpeed, ForceMode2D.Impulse);

        curShotDelay = 0;
        }
    }

    public void onHit(float dmg)
    {
        enemyHealth -= dmg;

        if (enemyHealth >= 0)
        {
            spriteRenderer.color = new Color(1,0,0,0.3f);
            Invoke("ReturnSprite", 0.2f);
        }
        StartCoroutine(CheckEnemyHealth());
    }
    
    void ReturnSprite()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void setEx()
    {
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
    void setAnimator()
    {
        switch (enemyType)
        {
            case Type.A:
                anim.SetTrigger("Dead");

                break;
            case Type.B:
                anim.SetTrigger("Dead");

                break;
            case Type.C:
                break;
        }
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
        else if (other.gameObject.CompareTag("Skill")) // ����(�����)
        {
            Skill_Guardian skill_Guardian = other.gameObject.GetComponent<Skill_Guardian>();
            onHit(skill_Guardian.dmg);
            takeDamageText(skill_Guardian.dmg);
        }
        else if (other.gameObject.CompareTag("Skill2")) // EMP�ʵ�(�ڱ���)
        {
            isHit = true;
            Skill_Magnetic skill_Magnetic = other.gameObject.GetComponent<Skill_Magnetic>();
            onHit(skill_Magnetic.dmg);
            takeDamageText(skill_Magnetic.dmg);
        }
        else if (other.gameObject.CompareTag("Skill3")) // ����
        {
            Skill_Ax skill_Ax = other.gameObject.GetComponent<Skill_Ax>();
            onHit(skill_Ax.dmg);
            takeDamageText(skill_Ax.dmg);
            //knockback.PlayFeedbackM(skill_Magnetic.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isHit = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Basketball")
        {
            BasketBall basket = collision.gameObject.GetComponent<BasketBall>();
            onHit(basket.basketdmg);
            takeDamageText(basket.basketdmg);
        }
    }

    void takeDamageText(float damage)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = this.gameObject.transform.position + new Vector3(0, 0.2f, 0);  // �ڱ� �ڽ� �Ӹ� ���� ������ ǥ��
        hudText.GetComponent<DamageText>().damage = damage;
    }

    IEnumerator CheckEnemyHealth()
    {
            if (enemyHealth <= 0)
            {
                isAlive = false;
                enemySpeed = 0;
                gameObject.layer = 0;

                setAnimator();

                yield return new WaitForSeconds(1.0f);
                setEx();
            }
            yield return new WaitForEndOfFrame(); // �� �������� ������ ���� ����
    }

}