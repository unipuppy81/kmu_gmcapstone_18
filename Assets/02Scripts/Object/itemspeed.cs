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

            pm.moveSpeed += 0.5f;
            if (pm.moveSpeed >= pm.maxSpeed)
            {
                pm.moveSpeed = pm.maxSpeed;
            }
        }
    }
}
