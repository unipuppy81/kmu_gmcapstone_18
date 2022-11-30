using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class MagnetBoundary : MonoBehaviour
{
    public Vector2 newPosition;
    private Transform trans;

    void Awake()
    {
        //trans = transform;
    }

    void Update()
    {
        /*trans.position = Vector2.Lerp(trans.position, newPosition, Time.deltaTime * 1.5f);

        if(Math.Abs(newPosition.x - trans.position.x) < 0.05)
        {
            trans.position = newPosition;
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ex")
        {
            
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<Magnet>(out Magnet magnet))
        {
            magnet.setTarget(transform.parent.position);
        }
    }*/
}
