using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ax : MonoBehaviour
{
    public static int axLevel = 0;
    public float axdmg;
    public bool level1, level2, level3, level4, level5;

    float rotationSpeed = 500f;

    public int dmg = 3;

    float axTime;

    Player player;
    SpriteRenderer spriteR;
    public Sprite sprites;

    ButtonManager buttonManager;
    new Rigidbody2D rigidbody2D;

    public Vector2 fired;

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
        axdmg = 1f;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        axTime += Time.deltaTime;
        axLife();
        Debug.Log(axTime);        

        if (axTime == 1.5f)
        {
            rigidbody2D.velocity = Vector2.zero;
            Debug.Log("1초");
        }
        else if (axTime > 1.5f)
        {
            //fired = (player.transform.position - transform.position).normalized;
            //rigidbody2D.velocity = fired * 6f;
            rigidbody2D.velocity = Player.axfire2d * -6f;
            Debug.Log("1초 후 되돌아옴");
        }

        if (Input.GetKeyDown(KeyCode.R))
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
        if (axLevel == 2)
        {
            dmg = 1;
            level1 = false;
            level2 = true;
        }
        else if (axLevel == 4)
        {
            dmg = 2;
            level2 = false;
            level3 = true;
        }
        else if (axLevel == 6)
        {

            dmg = 2;
            level3 = false;
            level4 = true;
        }
        else if (axLevel == 8)
        {
            dmg = 3;
            level4 = false;
            level5 = true;
        }
        else if (axLevel == 10)
        {
            dmg = 5;
            spriteR.sprite = sprites;
        }
    }

    void axLife()
    {
        if (level5 == false)
        {

        }

        if (level5 == true)
        {
            if (axTime >= 4f)
            {
                axTime = 0f;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerMg"))
        {
            
        }
    }
}
