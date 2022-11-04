using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magnetic : MonoBehaviour
{
    public int dmg = 3;

    public Transform target;
    public GameObject magnetic;

    public int magneticLevel = 0;
    // Start is called before the first frame update
    void Start()
    {

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
                break;

            case 2:
                dmg = 5;
                break;

            case 3:
                dmg = 7;
                break;

            case 4:
                dmg = 10;
                break;
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
