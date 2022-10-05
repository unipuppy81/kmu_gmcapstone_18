using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Player : MonoBehaviour
{ 
    //layer ���� �ʿ�
    [SerializeField] float searchRadius = 0f;
    [SerializeField] LayerMask layerMask = 0;
    [SerializeField] float fireRate = 0f;
    float currentFireRate;

    public Transform hit_target = null;  // ����Ÿ�� �ӽý���

    public GameObject bulletObjA;

    public int playerSpeed = 3;
    public float bulletSpeed = 2f;
    public float bulletDamage = 1f;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        currentFireRate = fireRate; 
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
    }

    void Update()
    { 
        Playermove();
    }

    void Playermove() 
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * playerSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }
    
    void SearchEnemy()                        
    {
        // OverlapCircleAll = ������ ���� ���� Ư�� layer ã����
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask); 
        Transform p_shortestTarget = null;

        if(colls.Length > 0)    // �迭 ũ�� 0���� ũ�� : ���� ���� ���� �ִ�.
        {
            float p_shortestDistance = Mathf.Infinity;

            UnityEngine.Debug.Log("Length > 0");

            foreach (Collider2D p_colTarget in colls)
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - p_colTarget.transform.position);
                if(p_shortestDistance > t_distance)
                {
                    p_shortestDistance = t_distance;
                    p_shortestTarget = p_colTarget.transform;
                }
            }
            // �Ʒ� 4�� : �� �ڵ� ���� �ڵ�
            Vector3 fire = p_shortestTarget.position - transform.position;
            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(fire * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            // �迭 ũ�� 0���� �۴� : ���� �ֺ��� �������� �ʴ´�.
            UnityEngine.Debug.Log("Length < 0");
        }
        hit_target = p_shortestTarget;
    }
}
