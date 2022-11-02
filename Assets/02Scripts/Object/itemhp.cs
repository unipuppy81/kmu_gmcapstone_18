using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemhp : MonoBehaviour
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

            player.playercurHp += 2f;
            if (player.playercurHp >= player.playerMaxHp)
            {
                player.playercurHp = player.playerMaxHp;
            }
        }
    }
}
