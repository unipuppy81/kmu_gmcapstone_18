using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum Type { A,B,C };
    public Type enemyType;
    public int maxHealth = 10;
    public int curHealth;
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;
    public int curmoveCount;
    public int maxmmoveCount = 2;
    public float speed = 2.0f;
    public float maxSDelay = 0.2f;
    public float curSDelay;

    private Transform myTransform = null;

    public bool isWalk;
    public bool isPattern;
    public bool isDead;
    public bool correctPos;




    public GameObject Wall;
    public GameObject Rock;

    float dirx, diry, timerr, bdirx, bdiry;

    

    Vector3 a, b;
    Vector3 lookVec, crushVec, movePos;

    Transform btarget;

    void Awake()
    {
        btarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      
        isWalk = true;
        isPattern = false;

        timerr = 0.0f;
        curmoveCount = 0;

        dirx = btarget.position.x;
        diry = btarget.position.y;

        //StartCoroutine(Think());    
    }

    void Start()
    {

    }

    void Update()
    {
        Breload();

        if(transform.position != btarget.position) { 
            correctPos = false;
        }
        if(transform.position == btarget.position)
        {
            correctPos = true;
        }

        if (isWalk)
            Move();
        else if (isPattern)
            Pattern();
    }

    void Breload()
    {
        curSDelay += Time.deltaTime;
    }

    void isWalking()
    {
        isWalk = false;
        Pattern();
    }

    void Move()
    {
        a = new Vector3(dirx, diry, 0);
        transform.position = Vector2.MoveTowards(transform.position, a, 2.0f * Time.deltaTime);
        
        if (transform.position.x == dirx && transform.position.y == diry)
        {
            if (curmoveCount != maxmmoveCount) 
            {
                int num = UnityEngine.Random.Range(0, 4);
                float ndirx, ndiry;
                switch (num)
                {
                case 0:
                    ndirx = transform.position.x;
                    ndiry = transform.position.y + 2.0f;
                    timerr += Time.deltaTime;
                    if (timerr >= 3.0f && timerr <= 3.2f)
                        {
                        
                        curmoveCount++;
                    }
                    if (timerr >= 3.0f)
                    {
                            
                            dirx = ndirx;
                        diry = ndiry;

                        timerr = 0.0f;
                    }
                    break;
                case 1:
                    ndirx = transform.position.x + 2.0f;
                    ndiry = transform.position.y;
                    timerr += Time.deltaTime;
                        if (timerr >= 3.0f && timerr <= 3.2f)
                        {
                           
                            curmoveCount++;
                        }
                    if (timerr >= 3.0f)
                    {
                            
                            dirx = ndirx;
                        diry = ndiry;
                        timerr = 0.0f;
                    }
                    break;
                case 2:
                    ndirx = transform.position.x - 2.0f;
                    ndiry = transform.position.y;
                    timerr += Time.deltaTime;
                    if (timerr >= 3.0f && timerr <= 3.2f)
                        {
                     
                        curmoveCount++;
                    }
                    if (timerr >= 3.0f)
                    {
                           
                            dirx = ndirx;
                        diry = ndiry;
                        timerr = 0.0f;
                    }
                    break;
                case 3:
                    ndirx = transform.position.x;
                    ndiry = transform.position.y - 2.0f;
                    timerr += Time.deltaTime;
                    if (timerr >= 3.0f && timerr <= 3.2f)
                        {
               
                        curmoveCount++;
                    }
                    if (timerr >= 3.0f)
                    {
               
                            dirx = ndirx;
                        diry = ndiry;

                        timerr = 0.0f;
                    }
                    break;
                }
            }
        
            if(curmoveCount == maxmmoveCount)
            {
                isWalk = false;
                isPattern = true;
                curmoveCount = 0;
            }
        }
        
    }

    void Pattern()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                RandAttack();
                break;

            case 1:
                RockAttack();
                break;

            case 2:
                CrushAttack();
                break;
        }
        isWalk = true;
        isPattern = false;
    }
    
    void RandAttack()
    {
        curPatternCount++;

            for(int i = 0; i < 5; i++)
            {
                float attackPosx1 = 5f;
                float attackPosy1 = 5f;

                float attackPosx2 = -5f;
                float attackPosy2 = -5f;

                float arandomX = UnityEngine.Random.Range(attackPosx1, attackPosx2);
                float arandomY = UnityEngine.Random.Range(attackPosy1, attackPosy2);

                GameObject wall = (GameObject)Instantiate(Wall, new Vector3(arandomX, arandomY, 0f), Quaternion.identity);
            }

        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("RandAttack", 2);
        //else
           // Invoke("Pattern", 3);
    }

    void RockAttack()
    {
        curPatternCount++;
        if(curSDelay < maxSDelay)
        {
            return;
        }

            for(int i=0; i < 1; i++)
            {
               Vector3 Rockshot = btarget.position - transform.position;
               GameObject rock = Instantiate(Rock, transform.position, transform.rotation);
               Rigidbody2D rigid = rock.GetComponent<Rigidbody2D>();
               rigid.AddForce(Rockshot * 3.0f, ForceMode2D.Impulse);

               curSDelay = 0;
             }


        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("RockAttack", 2);
       // else
           // Invoke("Pattern", 3);
    }

    void CrushAttack()
    {
        UnityEngine.Debug.Log("순간이동 or 잡몹생성");
        curPatternCount++;

        movePos = btarget.position - transform.position;

        int loopNum = 0;

        b = new Vector3(bdirx, bdiry, 0);
        transform.position = Vector2.MoveTowards(transform.position, a, 2.0f * Time.deltaTime);

        //while (!correctPos)
        //{
        //    if(loopNum++ > 100)
        //    {
        //        throw new Exception("Loop");
        //    }
        //    UnityEngine.Debug.Log("987");
        //    transform.Translate(movePos * Time.deltaTime);
        //    UnityEngine.Debug.Log("000");
        //    if(transform.position.x == dirx && transform.position.y == diry)
        //    {
        //        UnityEngine.Debug.Log("999");
        //        break;
        //    }
        //}
        /*
        if (transform.position != btarget.position) {
            UnityEngine.Debug.Log("987");
            float dir01 = 10f * Time.deltaTime;
            float dir02 = 10f * Time.deltaTime;

            Vector3 a = new Vector3(dir01, dir02, 0);
            transform.Translate(a);
            //transform.Translate(movePos * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, btarget.position, 4.0f * Time.deltaTime);
        }
        */
        if (curPatternCount < maxPatternCount[patternIndex])
        {

            Invoke("CrushAttack", 2);
        }
     }


   

    IEnumerator Move1()
    {
        //boss = GetComponent<Rigidbody>();

        while (true)
        {
            //float dir1 = UnityEngine.Random.Range(-2f, 2f);
            //float dir2 = UnityEngine.Random.Range(-2f, 2f);

            float dir1 = 10f * Time.deltaTime;
            float dir2 = 10f * Time.deltaTime;

            Vector3 a = new Vector3(dir1, dir2, 0);

            yield return new WaitForSeconds(2);
            transform.Translate(a);
        }
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(2.0f); // 난이도 조절할때 사용

        int ranAction = UnityEngine.Random.Range(0, 3);

        switch (ranAction)
        {
            case 0:
                // 랜덤 공격
                isWalk = false;
                StartCoroutine(RandAttack1());
                isWalk = true;
                break;
            case 1:
                // 범위 공격
                isWalk = false;
                StartCoroutine(RockAttack1());
                isWalk = true;
                break;
            case 2:
                // 돌진
                isWalk = false;
                StartCoroutine(CrushAttack1());
                isWalk = true;
                break;
        }
    }

    IEnumerator RandAttack1()
    {
       UnityEngine.Debug.Log("A");

       yield return new WaitForSeconds(3.0f);

       StartCoroutine(Think());
    }

    IEnumerator RockAttack1()
        {
            UnityEngine.Debug.Log("B");
            yield return new WaitForSeconds(3.0f);

            StartCoroutine(Think());
        }

    IEnumerator CrushAttack1()
        {
            UnityEngine.Debug.Log("C");
            //boxCollider.enabled = false;


            // +crush anim
            if (transform.position != btarget.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, btarget.position, 10f * Time.deltaTime);
            }
            yield return new WaitForSeconds(1.0f);

            StartCoroutine(Think());
        }
}