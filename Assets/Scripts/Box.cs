using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

public class Box : MonoBehaviour
{

    public GameObject item_hp;
    public GameObject item_speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Skill1")
        {
            Destroy(this.gameObject);

            float randI = UnityEngine.Random.Range(0, 10);

            if (randI >= 0 && randI <= 5){
                Instantiate(item_hp, transform.position, item_hp.transform.rotation);
            }
            else if(randI >= 5 && randI <= 10){
                Instantiate(item_speed, transform.position, item_speed.transform.rotation);
            }

        }
    }

}
