using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BasketBall : MonoBehaviour
{
    public static int baskeetballLevel = 0;
    public float basketdmg;
    public bool level1, level2, level3, level4, level5;

    float basketTime;

    SpriteRenderer spriteR;

    public Sprite sprites;


    void Awake()
    {
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        basketdmg = 1f;
    }

    void Start()
    {
       
    }

    void Update()
    {
        basketTime += Time.deltaTime;
        basketLife();

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            level5 = true;
            spriteR.sprite = sprites;
        }
    }

    void basketLife()
    {
        if(level5 == false)
        {
            if (basketTime >= 10f)
            {
                Destroy(this.gameObject);
                basketTime = 0f;
            }
        }

        if(level5 == true)
        {
            if (basketTime >= 5f)
            {
                basketTime = 0f;
            }
        }

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
