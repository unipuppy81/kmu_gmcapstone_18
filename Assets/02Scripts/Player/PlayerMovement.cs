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
    Animator anim;
    
    
    Rigidbody2D rb;
    public float moveSpeed = 3f;
    public float maxSpeed = 10f;
    public float s;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // 방향벡터.normalize(크기 1) * speed;

        float movehorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        s = moveVertical + movehorizontal;
        if(s < 0)
        {
            s *= -1;
        }

        rb.velocity = new Vector3(moveVertical * moveSpeed, moveVertical * moveSpeed,0.0f );
        rb.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x * moveSpeed, JoyStickMovement.Instance.joyVec.y * moveSpeed, 0.0f);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", s);
    }
   }
