using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Player player;

    public int wallDamage;
    void Awake()
    {
        wallDamage = 2;
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

            player.playercurHp -= wallDamage;

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
