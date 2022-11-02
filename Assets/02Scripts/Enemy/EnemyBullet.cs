using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    private float dmg;
    
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        enemy = GameObject.Find("Enemy2(Clone)").GetComponent<Enemy>();

        lifetime = 0f;

        dmg = enemy.enemyDamage;
    }

    // Update is called once per frame
    void Update()
    {
        alive();
    }

    void alive()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= 6.0f)
        {
            Destroy(gameObject);
            lifetime = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("원거리 공격 맞음");

            Destroy(gameObject);
        }
    }
}
