using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
