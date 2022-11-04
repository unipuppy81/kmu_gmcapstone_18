using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] GameObject pannel1;
    [SerializeField] GameObject pannel2;
    public void Set(upgradeManager upgradeManager)
    {
        icon.sprite = upgradeManager.icon;
    }

    public void buttonclick()
    {
        pannel1.SetActive(false);
        pannel2.SetActive(false);
        Time.timeScale = 1f;
    }
}
