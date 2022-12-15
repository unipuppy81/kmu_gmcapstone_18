using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magnetic : MonoBehaviour
{
    [SerializeField] private float damageTime = 0.5f; // 데미지가 들어갈 딜레이 (매 프레임마다가 아닌 일정 시간마다 데미지를 주기 위하여)
    private float currentDamageTime;

    public float dmg = 1;

    public Transform target;
    public GameObject magnetic;
    public GameObject magnetic2;

    public int magneticLevel = 0;

    public bool level1, level2, level3, level4, level5;
    public bool levelp1, levelp2, levelp3, levelp4, levelp5;

    ButtonManager buttonManager;

    Equip_Hot7 _Hot7;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        _Hot7 = GetComponent<Equip_Hot7>();
        enemy = GetComponent<Enemy>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();

        level1 = true;
        level2 = true;
        level3 = true;
        level4 = true;
        level5 = true;
        levelp1 = true;
        levelp2 = false;
        levelp3 = false;
        levelp4 = false;
        levelp5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        magneticLevel = buttonManager.empCount;
        levelDesign();
        Ppoppai();
        transform.position = target.position;
    }

    void levelDesign()
    {
        if (magneticLevel == 1 && level1 == true)
        {
            magnetic.SetActive(true);
            dmg = 1;
            level1 = false;
            level2 = true;
        }
        else if (magneticLevel == 2 && level2 == true)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            dmg = 1.2f;
            level2 = false;
            level3 = true;
        }
        else if (magneticLevel == 3 && level3 == true)
        {
            transform.localScale = new Vector3(0.55f, 0.55f, 1f);
            dmg = 1.3f;
            level3 = false;
            level4 = true;
        }
        else if (magneticLevel == 4 && level4 == true)
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            dmg = 1.4f;
            level4 = false;
            level5 = true;
        }
        else if (magneticLevel == 5 && level5 == true && Equip_Hot7.selectedHot7 == true)
        {
            magnetic.SetActive(false);
            magnetic2.SetActive(true);
            transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            dmg = 1.5f;
            level5 = false;
        }
    }

    void Ppoppai()
    {
        if (Equip_Spinach.ppoppaiLevel == 1 && levelp1 == true)
        {
            //dmg += 1f;
            levelp1 = false;
            levelp2 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 2 && levelp2 == true)
        {
            //dmg += 1f;
            levelp2 = false;
            levelp3 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 3 && levelp3 == true)
        {
           // dmg += 1f;
            levelp3 = false;
            levelp4 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 4 && levelp4 == true)
        {
            //dmg += 1f;
            levelp4 = false;
            levelp5 = true;
        }
        else if (Equip_Spinach.ppoppaiLevel == 5 && levelp5 == true)
        {
            //dmg += 1f;
            levelp5 = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            
        }

        if (collision.gameObject.tag == "Box")
        {
            
        }
    }
}
