using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    GameObject levelpanel;
    [SerializeField]
    GameObject Pausebutton;
    [SerializeField]
    TextMeshProUGUI levelText;
    [SerializeField]
    public List<GameObject> select1 = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select2 = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select3 = new List<GameObject>();
    [SerializeField]
    public Slider exbar;

    public GameObject gameclearPannel;
    public GameObject Bossalive;

    public float MaxEx;
    public float CurEx;

    public int levelCount;
    int i, j, k;
    public float ex1Amount = 1f;
    public float ex2Amount = 2f;

    public float _Sec;
    public int _min;
    public int _mina = 6;   
    public int min;
    public int max;


    Player player;
    ButtonManager btnmanager;

    private void Awake()
    {
        levelCount = 0;
        MaxEx = 5f;
        levelpanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {

        Timer();
        ActiveFalse();
        if(Bossalive.activeSelf == true)
        {
            if (Boss.bossCurHealth == 0 || Boss.bossCurHealth < 0)
            {
                Time.timeScale = 0f;
                gameclearPannel.SetActive(true);
                Boss.bossCurHealth = 100f;
            }
        }
        

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
            GameObject.Find("Ex");
            CurEx += ex1Amount;
            Debug.Log(CurEx);
            other.gameObject.SetActive(false);
            Level();
        }
        else if (other.gameObject.tag == "Ex2")
        {
            GameObject.Find("Ex2");
            CurEx += ex2Amount;
            Debug.Log(CurEx);
            other.gameObject.SetActive(false);
            Level();
        }
    }
    public void Level()
    {
        if (CurEx >= MaxEx)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
            if(levelCount <=10)
            {
                CurEx = 0;
                MaxEx += 1;
            }
            else if (levelCount > 10 && levelCount <= 20)
            {
                CurEx = 0;
                MaxEx += 5;
            }
            else if (levelCount > 20 && levelCount <= 30)
            {
                CurEx = 0;
                MaxEx += 10;
            }
            else if (levelCount > 30 && levelCount <= 40)
            {
                CurEx = 0;
                MaxEx += 20;
            }
        }
    }

    public void openPanel()
    {
        levelpanel.SetActive(true);
        Pausebutton.SetActive(false);
        Time.timeScale = 0f;

    }
    public void closePanel()
    {
        levelpanel.SetActive(false);
        Pausebutton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void leveltext()
    {
        levelText.text = string.Format("LV : {0:D1}", levelCount);
    }

    public void RandomChoose()
    {
        if (levelpanel.activeSelf == true)
        {
            i = UnityEngine.Random.Range(0, select1.Count);
            switch (i)
            {
                case 0:
                    select1[0].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 1:
                    select1[1].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 2:
                    select1[2].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 3:
                    select1[3].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 4:
                    select1[4].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 5:
                    select1[5].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 6:
                    select1[6].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 7:
                    select1[7].SetActive(true);
                    j = UnityEngine.Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = UnityEngine.Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = UnityEngine.Random.Range(0, select3.Count);
                    while (k == i || k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
            }
        }

    }

    public void ActiveFalse()
    {
        if (levelpanel.activeSelf == false)
        {
            for (int t = 0; t < select1.Count; t++)
            {
                select1[t].SetActive(false);
                select2[t].SetActive(false);
                select3[t].SetActive(false);
            }
        }
    }

    void Timer()
    {
        _Sec += Time.deltaTime;
        timeText.text = string.Format("{0:D2}:{1:D2}", _min, (int)_Sec);

        if ((int)_Sec > 59)
        {
            _Sec = 0;
            _min++;
        }
        if (_min == 6)
        {
            float _Seca = 0.0f;
            gameObject.SetActive(false);
            timeText.text = string.Format("{0:D2}:{1:D2}", _mina, (int)_Seca);
        }

    }
}
