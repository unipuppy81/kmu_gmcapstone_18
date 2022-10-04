using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public int health;
    public Sprite[] sprites;


    SpriteRenderer spriteRenderer; // 피격 애니메이션
    Rigidbody2D rigid;

 
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

    }
    

    void onHit(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(gameObject);
        }  
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player");
        {
            Destroy(this.gameObject);

            UnityEngine.Debug.Log("Enemy01 Boom");
        }
    }

}
