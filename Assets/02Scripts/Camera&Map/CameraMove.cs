using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;


    void Start()
    {

    }

    void LateUpdate() // update �ڿ� ȣ��
    {
        transform.position = new Vector3(target.position.x, target.position.y, -20.0f);
    }
    void Update()
    {
       
    }
}
