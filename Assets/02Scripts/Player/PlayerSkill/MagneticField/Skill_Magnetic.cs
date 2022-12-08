using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magnetic : MonoBehaviour
{
    [Header("ũ�� ����")]
    [SerializeField]
    [Range(1f, 5f)] float scaleSpeed = 1f;

    [SerializeField] private float damageTime = 0.5f; // �������� �� ������ (�� �����Ӹ��ٰ� �ƴ� ���� �ð����� �������� �ֱ� ���Ͽ�)
    private float currentDamageTime;

    public int dmg = 3;

    public UnityEngine.Transform target;
    public GameObject magnetic;

    public int magneticLevel = 0;

    public bool level1, level2, level3, level4, level5 = true;

    ButtonManager buttonManager;

    Equip_Hot7 _Hot7;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        _Hot7 = GetComponent<Equip_Hot7>();
        enemy = GetComponent<Enemy>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        magneticLevel = buttonManager.empCount;
        searchEnemy();
        levelDesign();
        transform.position = target.position;
        currentDamageTime = Time.deltaTime;
    }

    void searchEnemy()
    {
        GameObject[] enemy1 = GameObject.FindGameObjectsWithTag("Enemy01");
    }

    void levelDesign()
    {
        if (magneticLevel == 1 && level1 == true)
        {
            magnetic.gameObject.SetActive(true);
            dmg = 1;
            level1 = false;
            level2 = true;
        }
        else if (magneticLevel == 2 && level2 == true)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            dmg = 2;
            level2 = false;
            level3 = true;
        }
        else if (magneticLevel == 3 && level3 == true)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            dmg = 3;
            level3 = false;
            level4 = true;
        }
        else if (magneticLevel == 4 && level4 == true)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            dmg = 4;
            level4 = false;
            level5 = true;
        }
        else if (magneticLevel == 5 && level5 == true && Equip_Hot7.selectedHot7 == true)
        {
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
