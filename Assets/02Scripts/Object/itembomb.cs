using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembomb : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 1000f;



    private Player player;
    private Enemy enemy;

    Transform target;
    Rigidbody2D rigid;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            player.specialSkill += 1;
        }
    }
}
