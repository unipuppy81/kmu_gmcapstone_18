using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance
    {
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("PlayerMovement");
                    instance = instanceContainer.AddComponent<PlayerMovement>();
                }
            }
            return instance;
        }
    }
    private static PlayerMovement instance;
    Rigidbody2D rb;
    static public float moveSpeed = 3f;
    static public float maxSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ���⺤��.normalize(ũ�� 1) * speed;

        float movehorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(JoyStickMovement.Instance.joyVec.x * moveSpeed, JoyStickMovement.Instance.joyVec.y * moveSpeed, 0.0f);
        dir = dir.normalized;

        rb.velocity = new Vector3(moveVertical * moveSpeed, moveVertical * moveSpeed,0.0f );
        rb.velocity = dir * moveSpeed;
    }
}
