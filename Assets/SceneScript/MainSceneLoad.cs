using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoad : MonoBehaviour
{
    public void ChaneSceneBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
