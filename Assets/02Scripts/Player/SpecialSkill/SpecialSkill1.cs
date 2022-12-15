using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialSkill1 : MonoBehaviour
{
    [Header("크기속도 조절")]
    [SerializeField]
    [Range(0f, 10f)] float scaleSpeed = 7f;

    public int dmg = 30;
    Enemy enemy;

    void Update()
    {
        searchEnemy();
    }

    void searchEnemy()
    {
        GameObject[] enemy1 = GameObject.FindGameObjectsWithTag("Enemy01");
        //enemy = GetComponent<Enemy>();

        transform.localScale = new Vector3(transform.localScale.x - (1f * scaleSpeed * Time.deltaTime),
        transform.localScale.y - (1f * scaleSpeed * Time.deltaTime), 0);

        if (transform.localScale.x < 0.1f && transform.localScale.y < 0.1f)
        {
            for (int i = 0; i < enemy1.Length; i++)
            {
                enemy1[i].GetComponent<Enemy>().onHit(dmg);
            }
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
