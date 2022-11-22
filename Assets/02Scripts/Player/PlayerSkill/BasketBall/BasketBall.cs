using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BasketBall : MonoBehaviour
{
    public static int baskeetballLevel = 0;
    public float basketdmg;
    public bool level1, level2, level3, level4, level5 = true;

    float basketTime;



    void Awake()
    {
        basketdmg = 1f;
    }

    void Start()
    {
       
    }

    void Update()
    {
        basketTime += Time.deltaTime;
        basketLife();
    }

    void basketLife()
    {
        if (basketTime >= 10f)
        {
            Destroy(this.gameObject);
            basketTime = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            UnityEngine.Debug.Log("적 피 깎임");
        }

        if (collision.gameObject.tag == "Boss")
        {
            UnityEngine.Debug.Log("보스 피 깎임");
        }
    }
}
