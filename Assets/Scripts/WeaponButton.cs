using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    public GameObject levelpanel;
    public GameObject PausBtn;

    int maxGuardians = 4;

    Skill_Guardian guardian;

    private void Start()
    {
        guardian = GameObject.Find("Front").GetComponent<Skill_Guardian>();
    }

    public void onClickBtn1()
    {
        levelpanel.SetActive(false);
        PausBtn.SetActive(true);
        Time.timeScale = 1f;
        if (guardian.hasGuardians < maxGuardians)
        {
            guardian.guardians[guardian.hasGuardians].SetActive(true);
            guardian.hasGuardians += 1;
        }
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
