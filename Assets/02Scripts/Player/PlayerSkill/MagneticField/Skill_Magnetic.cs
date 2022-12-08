using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magnetic : MonoBehaviour
{
    [SerializeField] private float damageTime = 0.5f; // �������� �� ������ (�� �����Ӹ��ٰ� �ƴ� ���� �ð����� �������� �ֱ� ���Ͽ�)
    private float currentDamageTime;

    public int dmg = 3;

    public Transform target;
    public GameObject magnetic;

    public int magneticLevel = 0;

    public bool level1, level2, level3, level4, level5;

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
    }

    // Update is called once per frame
    void Update()
    {
        magneticLevel = buttonManager.empCount;
        levelDesign();
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
            dmg = 2;
            level2 = false;
            level3 = true;
        }
        else if (magneticLevel == 3 && level3 == true)
        {
            transform.localScale = new Vector3(0.55f, 0.55f, 1f);
            dmg = 3;
            level3 = false;
            level4 = true;
        }
        else if (magneticLevel == 4 && level4 == true)
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            dmg = 4;
            level4 = false;
            level5 = true;
        }
        else if (magneticLevel == 5 && level5 == true && Equip_Hot7.selectedHot7 == true)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            dmg = 5;
            level5 = false;
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
