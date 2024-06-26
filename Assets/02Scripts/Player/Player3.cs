using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player3 : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        speed = 2.0f;
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextvec = inputVec * speed * Time.fixedDeltaTime; 
 
        rigid.MovePosition(rigid.position + nextvec);

    }

    void LateUpdate() // 프레임이 종료되기 전 실행
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }


    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
