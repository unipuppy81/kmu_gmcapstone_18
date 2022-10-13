using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSkill1 : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)] float scaleSpeed = 5f;

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

        transform.localScale = new Vector3(transform.localScale.x - 1f * scaleSpeed * Time.deltaTime,
            transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);

        if (transform.localScale.x < 0.1f)
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
            Destroy(gameObject);
            UnityEngine.Debug.Log("Àû Á×À½");
        }
    }
}
