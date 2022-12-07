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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            PlayerMovement.moveSpeed += 5.0f;
            if (PlayerMovement.moveSpeed >= PlayerMovement.maxSpeed)
            {
                PlayerMovement.moveSpeed = PlayerMovement.maxSpeed;
            }
        }
    }
}
