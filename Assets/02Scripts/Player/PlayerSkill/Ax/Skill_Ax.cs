using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ax : MonoBehaviour
{
    public static int axLevel = 0;
    public bool level1, level2, level3, level4, level5;
    public bool levelp1, levelp2, levelp3, levelp4, levelp5 = true;

    float rotationSpeed = 500f;

    public float dmg;

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

    public float axSpeed;

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

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        spawnPosx1 = transform.position.x + 1f;
        spawnPosy1 = transform.position.y + 1f;

        spawnPosx2 = transform.position.x - 1f;
        spawnPosy2 = transform.position.y - 1f;

        randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        axFired = new Vector3(randomX, randomY, 0);
        axfire2d = new Vector2(axFired.x, axFired.y).normalized;
        axSpeed = 1.0f;
    }

    void Start()
    {
        life = true;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        axTime += Time.deltaTime;

        if (axTime >= 0.0f && axTime <= 5.0f)
        {
            life = true;
        }

        if (axTime >= 0.0f && axTime < 1.5f)
        {
            rigidbody2D.velocity = axfire2d * axSpeed * 6f;
        }
        else if (axTime == 1.5f)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else if (axTime > 1.5f && axTime < 5.0f)
        {
            rigidbody2D.velocity = axfire2d * axSpeed * -6f;
        }
        else if (axTime >= 5.0f && axTime < 7.0f)
        {
            Destroy(gameObject);
            axTime = 0.0f;
            life = false;
        }
    }

    void FixedUpdate()
    {
        LevelDesign();
        AxLevel();
        Ppoppai();
    }

    void AxLevel()
    {
        if (axLevel == 1 || axLevel == 3 || axLevel == 5 || axLevel == 7 || axLevel == 9)
        {
            AxScript();
            axLevel++;
        }
    }

    public void AxScript()
    {
        if (!life) { 
        GameObject ax = Instantiate(Ax, player.transform.position, player.transform.rotation);
        }
    }

    void LevelDesign()
    {
        if (axLevel == 2)
        {
            dmg = 2;
            axSpeed = 1.2f;
            level1 = false;
            level2 = true;
        }
        else if (axLevel == 4)
        {
            //transform.localScale = new Vector3(0.08f, 0.08f, 1f);
            dmg = 2;
            axSpeed = 1.4f;
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
            //transform.localScale = new Vector3(0.15f, 0.15f, 1f);
            dmg = 4;
            axSpeed = 1.8f;
            level4 = false;
            level5 = true;
        }
        else if (axLevel >= 10 && Equip_MagInc.selectedMagnetInc == true)
        {
            transform.localScale = new Vector3(0.20f, 0.20f, 1f);
            axSpeed = 2.0f;
            dmg = 5;
            spriteR.sprite = sprites;
        }
    }

    void Ppoppai()
    {
        if (Equip_Spinach.ppoppaiLevel == 1 && levelp1 == true)
        {
            dmg += 1f;
            levelp1 = false;
            levelp2 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 2 && levelp2 == true)
        {
            dmg += 1f;
            levelp2 = false;
            levelp3 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 3 && levelp3 == true)
        {
            dmg += 1f;
            levelp3 = false;
            levelp4 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 4 && levelp4 == true)
        {
            dmg += 1f;
            levelp4 = false;
            levelp5 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 5 && levelp5 == true)
        {
            dmg += 1f;
            levelp5 = false;
        }
    }
}
