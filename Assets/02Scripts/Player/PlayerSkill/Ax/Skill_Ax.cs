using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ax : MonoBehaviour
{
    public int dmg = 3;
    float rotationSpeed = 500f;

    float axTime;
    public GameObject Ax;
    public GameObject player;

    public static int axLevel = 0;
    public bool level1, level2, level3, level4, level5 = true;

    public Vector3 axfire;
    public Vector2 axfire2d;
    public Vector3 axPosition;
    public Vector2 axFire;

    public bool go;

    ButtonManager buttonManager;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        player = GameObject.Find("Player");
        StartCoroutine(Boom());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        axTime += Time.deltaTime;
        axLevel = buttonManager.axCount;
        //axLife();
        //LevelDesign();
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }

    void instantiate()
    {
        float spawnPosx1 = transform.position.x + 1f;
        float spawnPosy1 = transform.position.y + 1f;

        float spawnPosx2 = transform.position.x - 1f;
        float spawnPosy2 = transform.position.y - 1f;

        float randomX = UnityEngine.Random.Range(spawnPosx1, spawnPosx2);
        float randomY = UnityEngine.Random.Range(spawnPosy1, spawnPosy2);

        GameObject ax = Instantiate(Ax, transform.position, transform.rotation);
        Rigidbody2D rigid = ax.GetComponent<Rigidbody2D>();

        Vector3 axFired = new Vector3(randomX, randomY, 0);
        axfire2d = new Vector2(axFired.x, axFired.y).normalized;
        axFire = axfire2d * 7f;

        //rigid.AddForce(axfire2d * 10f, ForceMode2D.Impulse);
        rigid.velocity = new Vector2(axFire.x, axFire.y);

        if (axTime >= 1f)
        {
            rigid.velocity = new Vector2(-axFire.x, -axFire.y);
        }
        if (axTime >= 2f)
        {
            gameObject.SetActive(false);
            axTime = 0f;
        }
    }

    void axLife()
    {
        Rigidbody2D rigid = Ax.GetComponent<Rigidbody2D>();
        if (axTime >= 5f)
        {
            rigid.velocity = new Vector2(-axFire.x, -axFire.y);
        }
        if (axTime >= 10f)
        {
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
            axTime = 0f;
        }
    }

    void LevelDesign()
    {
        if (axLevel == 1 && level1 == true)
        {
            for(int i = 0; i < 1; i++)
            {
                instantiate();
            }
            dmg = 3;
            level1 = false;
            level2 = true;
        }
        else if (axLevel == 2 && level2 == true)
        {
            for(int i = 0; i < 2; i++)
            {
                instantiate();
            }
            dmg = 4;
            level2 = false;
            level3 = true;
        }
        else if (axLevel == 3 && level3 == true)
        {
            for (int i = 0; i < 2; i++)
            {
                instantiate();
            }
            dmg = 5;
            level3 = false;
            level4 = true;
        }
        else if (axLevel == 4 && level4 == true)
        {
            for (int i = 0; i < 3; i++)
            {
                instantiate();
            }
            dmg = 6;
            level4 = false;
            level5 = true;
        }
        /*else if (axLevel == 5 && level5 == true && Equip_Dumbbell.selectedDumbbell == true)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            dmg = 5;
            level5 = false;
        }*/
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
