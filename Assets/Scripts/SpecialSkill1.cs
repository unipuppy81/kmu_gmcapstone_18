using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpecialSkill1 : MonoBehaviour
{
    [Header("크기속도 조절")]
    [SerializeField]
    [Range(0f, 10f)] float scaleSpeed = 7f;

    public int dmg = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        searchEnemy();
    }
    void searchEnemy()
    {
        GameObject[] enemy1 = GameObject.FindGameObjectsWithTag("Enemy01");

        transform.localScale = new Vector3(transform.localScale.x - (1f * scaleSpeed * Time.deltaTime),
            transform.localScale.y - (1f * scaleSpeed * Time.deltaTime), 0);

        if (transform.localScale.x < 0.1f && transform.localScale.y < 0.1f)
        {
            Destroy(this.gameObject);

            for (int i = 0; i < enemy1.Length; i++)
            {
                Destroy(enemy1[i]);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            //Destroy(gameObject);
            UnityEngine.Debug.Log("적 죽음");
        }
    }
}
