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
