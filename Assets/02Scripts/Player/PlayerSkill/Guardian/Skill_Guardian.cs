using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Skill_Guardian : MonoBehaviour
{
    public GameObject[] guardians;
    public int hasGuardians = 0;

    public int dmg = 3;

    public float time = 360;

    public Transform target;
    public float orbitSpeed;
    Vector3 offset;

    public int guardianLevel = 0;

    Equip_Dumbbell _Dumbbell;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        _Dumbbell = GetComponent<Equip_Dumbbell>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position, Vector3.forward, orbitSpeed * Time.deltaTime);
        transform.rotation = Quaternion.identity;

        offset = transform.position - target.position;

        levelDesign();
    }

    void levelDesign()
    {
        switch (guardianLevel)
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
        if(guardianLevel == 5 && _Dumbbell.selectedDumbbell == true) // 최종 진화
        {
            dmg = 15;
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
