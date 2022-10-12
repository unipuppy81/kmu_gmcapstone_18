using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPauseed = false;
    public GameObject pauseMenuButton;
    public GameObject pausePanel;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }
    public void onClickPause()
    {
        if(GameIsPauseed)
        {
            Resume();
        }
        else
        {
            Pause();
            pausePanel.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPauseed = false;
        pausePanel.SetActive(false);
    }
    public void Pause()
    {
        pauseMenuButton.SetActive(true);
        Time.timeScale = 0f;
        GameIsPauseed = true;
    }

    public void ToMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
