using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxCullTime : MonoBehaviour
{
    Player player;
    float cullTime;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        cullTime += Time.deltaTime;

        if(cullTime >= 6.0f)
        {
            player.axScript();
            cullTime = 0.0f;
        }
    }
}
