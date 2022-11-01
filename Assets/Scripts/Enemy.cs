using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject dropEx;

    public float enemyHealth = 2f;
    public float enemySpeed = 1f;

    SpriteRenderer spriteRenderer; // 피격 애니메이션
    Rigidbody2D rigid;
    Transform target;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
    }

    void onHit(float dmg)
    {
        enemyHealth -= dmg;

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(dropEx, transform.position, dropEx.transform.rotation);
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
        else if (other.gameObject.CompareTag("Skill"))
        {
            Skill_Guardian skill_Guardian = other.gameObject.GetComponent<Skill_Guardian>();
            onHit(skill_Guardian.dmg);
        }
        else if (other.gameObject.CompareTag("Skill2"))
        {
            Skill_Magnetic skill_Magnetic = other.gameObject.GetComponent<Skill_Magnetic>();
            onHit(skill_Magnetic.dmg);
        }
    }
}
