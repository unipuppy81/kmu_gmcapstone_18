using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magnetic : MonoBehaviour
{
    [Header("크기속도 조절")]
    [SerializeField]
    [Range(0f, 10f)] float scaleSpeed = 1f;

    public int dmg = 3;

    public Transform target;
    public GameObject magnetic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        searchEnemy();
        transform.position = target.position;
    }

    void searchEnemy()
    {
        GameObject[] enemy1 = GameObject.FindGameObjectsWithTag("Enemy01");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Box")
        {
            //Destroy(gameObject);
        }
    }
}
