using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxCullTime : MonoBehaviour
{
    Player player;
    float cullTime;

    Skill_Ax ax;

    private void Awake()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        ax = GameObject.Find("AX").GetComponent<Skill_Ax>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        cullTime += Time.deltaTime;

        if (cullTime >= 7.0f && Skill_Ax.axLevel >= 1 && Skill_Ax.life == false)
        {
            ax.AxScript();
            cullTime = 0.0f;
        }
        
    }
}
