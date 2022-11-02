using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemmagnet : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float searchRadius = 1000f;

    private Player player;

    GameObject Ex;
    Transform target;
    Rigidbody2D rigid;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);


            Collider2D[] colls = Physics2D.OverlapCircleAll(target.position, searchRadius, layerMask);

            foreach (Collider2D p_Target in colls)
            {
                Vector3 fire = target.position - p_Target.transform.position;
                Rigidbody2D rigid = p_Target.GetComponent<Rigidbody2D>();

                rigid.AddForce(fire * 100, ForceMode2D.Impulse);
            }
        }
    }
}
