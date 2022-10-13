using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    public GameObject levelpanel;
    public GameObject PausBtn;
    public void onClickBtn1()
    {
        levelpanel.SetActive(false);
        PausBtn.SetActive(true);
        Time.timeScale = 1f;
    }

    public void onClickBtn2()
    {
        levelpanel.SetActive(false);
        PausBtn.SetActive(true);
        Time.timeScale = 1f;
    }

    public void onClickBtn3()
    {
        levelpanel.SetActive(false);
        PausBtn.SetActive(true);
        Time.timeScale = 1f;
    }
}
