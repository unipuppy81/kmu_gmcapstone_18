using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class itemmagnet : MonoBehaviour
{
    Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            player.isMagnet = true;
        }
 
    }
}
