using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public static bool GameIsPauseed = false;
    public GameObject ButtonName;
    public GameObject pausePanel;
    public GameObject levelpanel;

    int maxGuardians = 4;

    Skill_Guardian guardian;
    Skill_Magnetic magneticField;
    Player player;
    Bullet bullet;

    private void Start()
    {
        guardian = GameObject.Find("Front").GetComponent<Skill_Guardian>();
        player = GameObject.Find("Player").GetComponent<Player>();
        magneticField = GameObject.Find("MagneticField").GetComponent<Skill_Magnetic>();
    }

    public void PauseClick()
    {
        if (GameIsPauseed)
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
        ButtonName.SetActive(true);
        Time.timeScale = 0f;
        GameIsPauseed = true;
    }

    public void ToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void WpBtn1()
    {
        levelpanel.SetActive(false);
        ButtonName.SetActive(true);
        Time.timeScale = 1f;
        if (guardian.hasGuardians < maxGuardians)
        {
            guardian.guardians[guardian.hasGuardians].SetActive(true);
            guardian.hasGuardians += 1;
        }
    }

    public void WpBtn2()
    {
        levelpanel.SetActive(false);
        ButtonName.SetActive(true);
        Time.timeScale = 1f;
        player.bulletDamage += 2f;
    }

    public void WpBtn3()
    {
        levelpanel.SetActive(false);
        ButtonName.SetActive(true);
        Time.timeScale = 1f;
        for (int i = 0; i < 1; i++)
        {
            magneticField.magnetic.SetActive(true);
        }
    }
}
