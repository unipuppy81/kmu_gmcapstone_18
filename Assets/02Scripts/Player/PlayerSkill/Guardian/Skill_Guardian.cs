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

    public int dmg = 3;

    public float time = 360;

    public float rotationSpeed = 50f;

    public Transform target;
    public float orbitSpeed;
    Vector3 offset;

    public static int guardianLevel = 0;
    public bool level1, level2, level3, level4, level5 = true;

    //Equip_Dumbbell _Dumbbell;

    ButtonManager buttonManager;

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
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        offset = transform.position - target.position;

        guardianLevel = buttonManager.sheildCount;
        LevelDesign();
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
            dmg = 2;
            level2 = false;
            level3 = true;
        }
        else if (guardianLevel == 3 && level3 == true)
        {
            guardians[hasGuardians].SetActive(true);
            hasGuardians += 1;
            dmg = 2;
            level3 = false;
            level4 = true;
        }
        else if (guardianLevel == 4 && level4 == true)
        {
            guardians[hasGuardians].SetActive(true);
            hasGuardians += 1;
            dmg = 3;
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
