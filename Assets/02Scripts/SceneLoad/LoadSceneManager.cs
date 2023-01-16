using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void MainLoad()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StoreLoad()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void CharacterLoad()
    {
        SceneManager.LoadScene("CharacterScene");
    }
    public void EvolutionLoad()
    {
        SceneManager.LoadScene("EvolutionScene");
    }
    public void ChallengeLoad()
    {
        SceneManager.LoadScene("ChallengeScene");
    }
    public void GameSceneLoad()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void SelectStageSceneLoad()
    {
        SceneManager.LoadScene("SelectStageScene");
    }
    public void MainLoad2()
    {
        SceneManager.LoadScene("MainScene2");
    }
}
