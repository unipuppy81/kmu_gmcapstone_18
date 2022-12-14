using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BasketBall : MonoBehaviour
{
    public static int basketballLevel = 0;
    public bool level1, level2, level3, level4, level5;
    public bool levelp1, levelp2, levelp3, levelp4, levelp5;

    public float basketdmg = 3;

    float basketTime;

    Player player;
    SpriteRenderer spriteR;

    ButtonManager buttonManager;

    public Sprite sprites;


    void Awake()
    {
        level1 = true;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        levelp1 = true;
        levelp2 = false;
        levelp3 = false;
        levelp4 = false;
        levelp5 = false;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
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

    void FixedUpdate()
    {
        LevelDesign();
        Ppoppai();
    }

    void LevelDesign()
    {
        if (basketballLevel == 2)
        {
            basketdmg = 3;
            level1 = false;
            level2 = true;
        }
        else if (basketballLevel == 4)
        {
            basketdmg = 4;

            level2 = false;
            level3 = true;
        }
        else if (basketballLevel == 6)
        {
            basketdmg = 5;

            level3 = false;
            level4 = true;
        }
        else if (basketballLevel == 8)
        {
            basketdmg = 6;

            level4 = false;
            level5 = true;
        }
        else if (basketballLevel == 10 && Equip_BBShoes.selectedBBShoes == true)
        {
            basketdmg = 7;

            spriteR.sprite = sprites;
        }
    }

    void Ppoppai()
    {
        if (Equip_Spinach.ppoppaiLevel == 1 && levelp1 == true)
        {
            basketdmg += 1f;
            levelp1 = false;
            levelp2 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 2 && levelp2 == true)
        {
            basketdmg += 1f;
            levelp2 = false;
            levelp3 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 3 && levelp3 == true)
        {
            basketdmg += 1f;
            levelp3 = false;
            levelp4 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 4 && levelp4 == true)
        {
            basketdmg += 1f;
            levelp4 = false;
            levelp5 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 5 && levelp5 == true)
        {
            basketdmg += 1f;
            levelp5 = false;
        }
    }
        void basketLife()
        {
            if (level5 == false)
            {

            }

            if (level5 == true)
            {
                if (basketTime >= 5f)
                {
                    basketTime = 0f;
                }
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy01")
            {
                UnityEngine.Debug.Log("³ó±¸°øÃæµ¹");
                if (level5 == true)
                {

                }
            }
        }
}
