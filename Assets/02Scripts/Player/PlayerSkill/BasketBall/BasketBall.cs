using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BasketBall : MonoBehaviour
{
    public static int basketballLevel = 0;
    public float basketdmg;
    public bool level1, level2, level3, level4, level5;

    public int dmg = 3;

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
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        basketdmg = 1f;
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
    }

    void LevelDesign()
    {
        if (basketballLevel == 2)
        {
            dmg = 1;
            level1 = false;
            level2 = true;
        }
        else if (basketballLevel == 4)
        {
            dmg = 2;
            level2 = false;
            level3 = true;
        }
        else if (basketballLevel == 6)
        {

            dmg = 2;
            level3 = false;
            level4 = true;
        }
        else if (basketballLevel == 8)
        {
            dmg = 3;
            level4 = false;
            level5 = true;
        }
        else if (basketballLevel == 10)
        {
            dmg = 5;
            spriteR.sprite = sprites;
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

            if (level5 == true)
            {

            }
        }
    }

}
