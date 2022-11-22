using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BasketBall : MonoBehaviour
{
    public static int baskeetballLevel = 0;
    public float basketdmg;
    public bool level1, level2, level3, level4, level5 = true;

    

    void Awake()
    {
        basketdmg = 1f;
    }

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            UnityEngine.Debug.Log("Àû ÇÇ ±ðÀÓ");
        }

        if (collision.gameObject.tag == "Boss")
        {
            UnityEngine.Debug.Log("º¸½º ÇÇ ±ðÀÓ");
        }
    }
}
