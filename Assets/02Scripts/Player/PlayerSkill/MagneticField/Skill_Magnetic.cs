using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Skill_Magnetic : MonoBehaviour
{
    [Header("크기 조절")]
    [SerializeField]
    [Range(1f, 5f)] float scaleSpeed = 1f;

    public int dmg = 3;

    public UnityEngine.Transform target;
    public GameObject magnetic;

    public int magneticLevel = 0;

    Equip_Hot7 _Hot7;
    // Start is called before the first frame update
    void Start()
    {
        _Hot7 = GetComponent<Equip_Hot7>();
    }

    // Update is called once per frame
    void Update()
    {
        searchEnemy();
        levelDesign();
        transform.position = target.position;
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
                dmg = 3;
                transform.localScale = new Vector3(2, 2, 2);
                break;

            case 2:
                dmg = 5;
                transform.localScale = new Vector3(3, 3, 3); // 둘 중 좀 더 괜찮은 것으로
                /*transform.localScale = new Vector3(transform.localScale.x + 1.5f * scaleSpeed * Time.deltaTime,
                    transform.localScale.y + 1.5f * scaleSpeed * Time.deltaTime, 0);*/ 
                break;

            case 3:
                dmg = 7;
                transform.localScale = new Vector3(4, 4, 4);
                break;

            case 4:
                dmg = 9;
                transform.localScale = new Vector3(5, 5, 5);
                break;
        }
        if(magneticLevel == 5 && _Hot7.selectedHot7 == true)
        {
            dmg = 12;
            transform.localScale = new Vector3(6, 6, 6);
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
