using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed = 1f;
    public int enemyHealth = 2;
    public Sprite[] sprites;


    public GameObject dropEx;


    SpriteRenderer spriteRenderer; // �ǰ� �ִϸ��̼�

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

    void onHit(int dmg)
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
    }
}
