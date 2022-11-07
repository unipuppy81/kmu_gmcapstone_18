using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    Equip_Hot7 _Hot7;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        _Hot7 = GetComponent<Equip_Hot7>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
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
        switch (magneticLevel)
        {
            case 1:
                transform.localScale = new Vector3(2, 2, 2);
                if(currentDamageTime >= damageTime)
                {
                    dmg = 3;
                    currentDamageTime = 0;
                }
                else
                {
                    dmg = 0;
                }
                
                break;

            case 2:
                transform.localScale = new Vector3(3, 3, 3); // �� �� �� �� ������ ������
                /*transform.localScale = new Vector3(transform.localScale.x + 1.5f * scaleSpeed * Time.deltaTime,
                    transform.localScale.y + 1.5f * scaleSpeed * Time.deltaTime, 0);*/
                if (currentDamageTime >= damageTime)
                {
                    dmg = 5;
                    currentDamageTime = 0;
                }
                else
                {
                    dmg = 0;
                }

                break;

            case 3:
                transform.localScale = new Vector3(4, 4, 4);
                if (currentDamageTime >= damageTime)
                {
                    dmg = 7;
                    currentDamageTime = 0;
                }
                else
                {
                    dmg = 0;
                }

                break;

            case 4:
                transform.localScale = new Vector3(5, 5, 5);
                if (currentDamageTime >= damageTime)
                {
                    dmg = 9;
                    currentDamageTime = 0;
                }
                else
                {
                    dmg = 0;
                }

                break;
        }
        if(magneticLevel == 5 && _Hot7.selectedHot7 == true)
        {
            transform.localScale = new Vector3(6, 6, 6);
            if (currentDamageTime >= damageTime)
            {
                dmg = 12;
                currentDamageTime = 0;
                enemy.enemySpeed *= 0.8f;
            }
            else
            {
                dmg = 0;
            }

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