using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneLoad : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            LoadingSceneController.LoadScene("MainScene");
        }
    }
}
