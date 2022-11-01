using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Player player;
    public float dmg;

    void Awake()
    {

    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        dmg = player.bulletDamage;
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }

}
