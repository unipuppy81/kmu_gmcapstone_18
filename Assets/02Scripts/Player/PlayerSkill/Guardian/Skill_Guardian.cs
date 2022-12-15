using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Guardian : MonoBehaviour
{
    public GameObject[] guardians;
    public GameObject[] guardians2;
    public int hasGuardians = 0;
    public int maxGuardians = 4;

    public float dmg = 3;

    public float time = 360;

    public float rotationSpeed;

    public Transform target;
    public float orbitSpeed;
    Vector3 offset;

    public static int guardianLevel = 0;
    public bool level1, level2, level3, level4, level5 = true;
    public bool levelp1, levelp2, levelp3, levelp4, levelp5;

    //Equip_Dumbbell _Dumbbell;

    ButtonManager buttonManager;

    void Awake()
    {
        rotationSpeed = 200f;
        level1 = true;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
        levelp1 = true;
        levelp2 = false;
        levelp3 = false;
        levelp4 = false;
        levelp5 = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position, Vector3.forward, orbitSpeed * Time.deltaTime);
        transform.rotation = Quaternion.identity;

        offset = transform.position - target.position;

        guardianLevel = buttonManager.sheildCount;
        LevelDesign();
        Ppoppai();
    }

    void LevelDesign()
    {
        if(guardianLevel == 1 && level1 == true)
        {
            guardians[hasGuardians].SetActive(true);
            hasGuardians += 1;
            dmg = 1;
            level1 = false;
            level2 = true;
        }
        else if(guardianLevel == 2 && level2 == true)
        {
            guardians[hasGuardians].SetActive(true);
            hasGuardians += 1;
            dmg = 1.2f;
            level2 = false;
            level3 = true;
        }
        else if (guardianLevel == 3 && level3 == true)
        {
            guardians[hasGuardians].SetActive(true);
            hasGuardians += 1;
            dmg = 1.5f;
            level3 = false;
            level4 = true;
        }
        else if (guardianLevel == 4 && level4 == true)
        {
            guardians[hasGuardians].SetActive(true);
            hasGuardians += 1;
            dmg = 2;
            level4 = false;
            level5 = true;
        }
        else if(guardianLevel == 5 && level5 == true && Equip_Dumbbell.selectedDumbbell == true) 
        {
            for(int i = 0; i < 4; i++)
            {
                guardians[i].SetActive(false);
                guardians2[i].SetActive(true);
            }
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            dmg = 3;
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
            //dmg += 1f;
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
