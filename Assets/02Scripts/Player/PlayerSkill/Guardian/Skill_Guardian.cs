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

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position, Vector3.forward, orbitSpeed * Time.deltaTime);

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
