using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Player player;
    public float lifetime;
    public int rockDamage;
    void Awake()
    {
        rockDamage = 10;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(30,0,0);
        alive();   
    }

    void alive()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= 3.0f)
        {
            Destroy(gameObject);
            lifetime = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("캐릭터 피 깎임");

            player.playercurHp -= rockDamage;

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject , 0.2f);
        }

    }
}
