using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

public class Box : MonoBehaviour
{

    public GameObject item_hp;
    public GameObject item_speed;
    public GameObject item_magnet;
    public GameObject item_bomb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Skill" || other.gameObject.tag == "Skill2")
        {
            Destroy(this.gameObject);

            float randI = UnityEngine.Random.Range(0, 10);

            if (randI >= 0 && randI <= 2){
                Instantiate(item_hp, transform.position, item_hp.transform.rotation);
            }
            else if(randI >= 2 && randI <= 4){
                Instantiate(item_speed, transform.position, item_speed.transform.rotation);
            }
            else if (randI >= 4 && randI <= 6)
            {
                Instantiate(item_magnet, transform.position, item_magnet.transform.rotation);
            }
            else if (randI >= 6 && randI <= 10)
            {
                Instantiate(item_bomb, transform.position, item_bomb.transform.rotation);
            }
        }
    }

}
