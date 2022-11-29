using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public GameObject SettingPanel;

    public void setting()
    {
        SettingPanel.SetActive(true);
    }
    public void closebtn()
    {
        SettingPanel.SetActive(false);
    }
}
