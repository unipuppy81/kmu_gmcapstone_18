using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoad : MonoBehaviour
{
    public void ChaneSceneBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
}
