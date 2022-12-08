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

    private Vector2 fired;

    private float spawnPosx1;
    private float spawnPosx2;
    private float spawnPosy1;
    private float spawnPosy2;

    private float randomX;
    private float randomY;

    private Vector3 axFired;
    private Vector2 axfire2d;

    public GameObject Ax;

    static public bool life;

    void Awake()
    {
        level1 = true;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        life = false;
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

        if (axTime >= 0.0f && axTime <= 5.0f)
        {
            life = true;
        }

        if(axLevel >= 10)
        {
            axLevel = 10;
        }

        if (axTime >= 0.0f && axTime < 1.5f)
        {
            rigidbody2D.velocity = axfire2d * 6f;
        }
        else if (axTime == 1.5f)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else if (axTime > 1.5f && axTime < 5.0f)
        {
            rigidbody2D.velocity = axfire2d * -6f;
        }
        else if (axTime >= 5.0f && axTime < 7.0f)
        {
            Destroy(gameObject);
            axTime = 0.0f;
            life = false;
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
        AxLevel();
    }

    void AxLevel()
    {
        if (axLevel == 1 || axLevel == 3 || axLevel == 5 || axLevel == 7)
        {
            AxScript();
            axLevel++;
        }
    }

    public void AxScript()
    {
        GameObject ax = Instantiate(Ax, player.transform.position, player.transform.rotation);
    }

    void LevelDesign()
    {
        if (axLevel == 2)
        {
            dmg = 2;
            level1 = false;
            level2 = true;
        }
        else if (axLevel == 4)
        {
            transform.localScale = new Vector3(0.08f, 0.08f, 1f);
            dmg = 2;
            level2 = false;
            level3 = true;
        }
        else if (axLevel == 6)
        {
            transform.localScale = new Vector3(0.12f, 0.12f, 1f);
            dmg = 3;
            level3 = false;
            level4 = true;
        }
        else if (axLevel == 8)
        {
            transform.localScale = new Vector3(0.15f, 0.15f, 1f);
            dmg = 4;
            level4 = false;
            level5 = true;
        }
        else if (axLevel == 10)
        {
            transform.localScale = new Vector3(0.20f, 0.20f, 1f);
            dmg = 5;
            spriteR.sprite = sprites;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
