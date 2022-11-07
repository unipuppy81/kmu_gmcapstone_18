using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspeed : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            player.playerSpeed += 1f;
            if (player.playercurHp >= player.maxSpeed)
            {
                player.playercurHp = player.maxSpeed;
            }
        }
    }
}