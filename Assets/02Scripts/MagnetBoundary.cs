using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class MagnetBoundary : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<Magnet>(out Magnet magnet))
        {
            magnet.setTarget(transform.parent.position);
        }
    }
}
