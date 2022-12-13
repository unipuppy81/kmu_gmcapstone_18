using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspeed : MonoBehaviour
{
    private Player player;
    private PlayerMovement pm;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            player.playerSpeed += 0.5f;
            if (player.playerSpeed >= player.maxSpeed)
            {
                player.playerSpeed = player.maxSpeed;
            }
            
        }
    }
}
