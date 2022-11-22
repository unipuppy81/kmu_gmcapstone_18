using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ax : MonoBehaviour
{
    public int dmg = 3;
    float rotationSpeed = 500f;

    float axTime;
    public GameObject Ax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        axTime += Time.deltaTime;
        axLife();
    }

    void axLife()
    {
        Rigidbody2D rigid = Ax.GetComponent<Rigidbody2D>();
        /*if (axTime >= 5f)
        {
            rigid.velocity = new Vector2(-axFire.x, -axFire.y);
        }*/
        if (axTime >= 10f)
        {
            Destroy(this.gameObject);
            axTime = 0f;
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
