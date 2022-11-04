using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public float maxEx = 1f;
    public float curEx = 0f;
    public GameObject btn1;
    public GameObject levelpanel;
    public GameObject upgradePanel;
    public GameObject PauseBtn;
    public float _Sec;
    public int _min;
    public int _mina = 6;
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    List<upgradeManager> upgrades;
    [SerializeField]
    List<UpgradeButton> upgradeButtons;

    private void Awake()
    {
        levelpanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
            GameObject.Find("Ex");
            curEx += 1f;
            Destroy(other.gameObject);
            if (curEx >= maxEx)
            {
                Time.timeScale = 0f;
                openPanel(GetUpgrades(3));
                curEx = 0f;
                maxEx += 1f;
            }
        }
    }
    private void Update()
    {
        Timer();
    }

    void Timer()
    {
        _Sec += Time.deltaTime;
        timeText.text = string.Format("{0:D2}:{1:D2}", _min, (int)_Sec);

        if((int)_Sec > 59)
        {
            _Sec = 0;
            _min++;
        }
        if (_min == 6)
        {
            float _Seca = 0.0f;
            timeText.text = string.Format("{0:D2}:{1:D2}", _mina, (int)_Seca);
        }
           
    }
    public List<upgradeManager> GetUpgrades(int count)
    {
        List<upgradeManager> upgradelist = new List<upgradeManager>();

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }
        for(int i = 0; i < count; i++)
        {
            upgradelist.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }
        return upgradelist;
    }
    public void openPanel(List<upgradeManager> upgradeManagers)
    {
        levelpanel.SetActive(true);
        upgradePanel.SetActive(true);
        PauseBtn.SetActive(false);
        for (int i = 0; i < upgradeManagers.Count; i++)
        {
            upgradeButtons[i].Set(upgradeManagers[i]);
        }
    }
}
