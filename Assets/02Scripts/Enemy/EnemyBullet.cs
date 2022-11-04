using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    private float dmg;
    
    public float lifetime;

    Skill_Guardian guardian;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        enemy = GameObject.Find("Enemy2(Clone)").GetComponent<Enemy>();
        guardian = GetComponent<Skill_Guardian>();

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
        else if(collision.gameObject.tag == "Skill" && guardian.guardianLevel == 5) // 가디언 최종 진화 시 적 총알이 막힘
        {
            Destroy(gameObject);
        }
    }
}
