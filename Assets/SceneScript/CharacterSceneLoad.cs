using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSceneLoad : MonoBehaviour
{
    public void ChaneSceneBtn()
    {
        SceneManager.LoadScene("CharacterScene");
    }
}
