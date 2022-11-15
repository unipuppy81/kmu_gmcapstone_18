using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BasketBall : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 0;

    private Player player;


    public static int baskeetballLevel = 0;
    public bool level1, level2, level3, level4, level5 = true;

    

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            UnityEngine.Debug.Log("Àû ÇÇ ±ðÀÓ");


            player.basketfire.x *= -1f;
            player.basketfire.y *= -1f;
        }

        if (collision.gameObject.tag == "Boss")
        {
            UnityEngine.Debug.Log("º¸½º ÇÇ ±ðÀÓ");

            player.basketfire.x *= -1f;
            player.basketfire.y *= -1f;
        }

        if( collision.gameObject.tag == "border")
        {

        }
    }
}
