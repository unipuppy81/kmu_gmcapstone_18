using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    public GameObject levelpanel;
    public void onClickBtn1()
    {
        levelpanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
