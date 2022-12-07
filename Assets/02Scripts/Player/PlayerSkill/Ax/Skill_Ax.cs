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
    float lifeCycle;

    Player player;
    SpriteRenderer spriteR;
    public Sprite sprites;

    ButtonManager buttonManager;
    new Rigidbody2D rigidbody2D;

    public Vector2 fired;

    public float spawnPosx1;
    public float spawnPosx2;
    public float spawnPosy1;
    public float spawnPosy2;

    public float randomX;
    public float randomY;

    public Vector3 axFired;
    public Vector2 axfire2d;

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

        spawnPosx1 = transform.position.x + 1f;
        spawnPosy1 = transform.position.y + 1f;

        spawnPosx2 = transform.position.x - 1f;
        spawnPosy2 = transform.position.y - 1f;

        randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        axFired = new Vector3(randomX, randomY, 0);
        axfire2d = new Vector2(axFired.x, axFired.y).normalized;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        axTime += Time.deltaTime;
        //Debug.Log(axTime);

        if (axTime >= 0.0f && axTime < 1.5f)
        {
            //rigidbody2D.AddForce(axfire2d * 6f, ForceMode2D.Impulse);
            rigidbody2D.velocity = axfire2d * 6f;
        }
        else if (axTime == 1.5f)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else if (axTime > 1.5f && axTime < 4.0f)
        {
            rigidbody2D.velocity = axfire2d * -6f;
        }
        else if (axTime >= 4.0f && axTime < 6.0f)
        {
            gameObject.SetActive(false);
        }
        else if (axTime >= 6.0f)
        {
            player.axScript();
            axTime = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            level5 = true;
            spriteR.sprite = sprites;
        }
        Debug.Log(lifeCycle);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerMg"))
        {
            
        }
    }
}
