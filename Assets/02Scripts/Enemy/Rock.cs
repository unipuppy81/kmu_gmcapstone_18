using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Player player;

    public int rockDamage;
    void Awake()
    {
        rockDamage = 10;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("캐릭터 피 깎임");

            player.playercurHp -= player.maxSpeed;

            Destroy(gameObject);
        }
        /*
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        */
    }
}
