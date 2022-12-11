using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using System;
using System.Linq;
using Unity.VisualScripting;
//using UnityEngine.UIElements;

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
    public List<GameObject> selectPanel = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select_coin_hp = new List<GameObject>();
   
    [SerializeField]
    public Slider exbar;

    public GameObject gameclearPannel;
    public GameObject Bossalive;
    public GameObject joystick;

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

    [SerializeField]
    public List<GameObject> empty = new List<GameObject>();
    public List<GameObject> bList;

    Vector3 posx1;
    Vector3 posx2;
    Vector3 posx3;
    Player player;
    ButtonManager btnmanager;

    private void Awake()
    {
        levelCount = 0;
        MaxEx = 5f;
        levelpanel.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1f;
        btnmanager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        //empty = new List<GameObject>();
        bList = new List<GameObject>(selectPanel);
    }

    public void Start()
    {
       posx1 = empty[0].transform.position;
       posx2 = empty[1].transform.position;
       posx3 = empty[2].transform.position;     
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
        selectPanel = new List<GameObject> (bList);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
            GameObject.Find("Ex");
            CurEx += ex1Amount;

            other.gameObject.SetActive(false);
            Level();
        }
        else if (other.gameObject.tag == "Ex2")
        {
            GameObject.Find("Ex2");
            CurEx += ex2Amount;
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
            Gatcha();
            if (levelCount <=10)
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
        //joystick.SetActive(false);
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
    /*
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
    */
    public void ActiveFalse()
    {
        if (levelpanel.activeSelf == false)
        {
            for (int t = 0; t < selectPanel.Count; t++)
            {
                selectPanel[t].SetActive(false);
                
            }
            for (int t = 0; t < select_coin_hp.Count; t++)
            {
                select_coin_hp[t].SetActive(false);
            }
            empty.Clear();
            
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

    public void Gatcha()
    {
        // 카운트가 5이상이면 selectPanel 에서 삭제
        if (levelpanel.activeSelf == true)
        {
            if (selectPanel.Count >= 3) //업그레이드할 무기가 3개 이상일때
            {
               
                for (int i = 0; i < 3; i++)
                {
                    int rand = UnityEngine.Random.Range(0, selectPanel.Count);
                    if (i == 0)
                    {
                        selectPanel[rand].transform.position = posx1;
                        selectPanel[rand].SetActive(true);
                        selectPanel.RemoveAt(rand);
                    }
                    if (i == 1)
                    {
                        selectPanel[rand].transform.position = posx2;
                        selectPanel[rand].SetActive(true);
                        selectPanel.RemoveAt(rand);
                    }
                    if (i == 2)
                    {
                        selectPanel[rand].transform.position = posx3;
                        selectPanel[rand].SetActive(true);
                        selectPanel.RemoveAt(rand);
                    }
                }
            }
            else if (selectPanel.Count == 2) // 업그레이드할 무기가 2개 남았을때
            {
                for (int i = 0; i < 2; i++)
                {
                    int rand = UnityEngine.Random.Range(0, selectPanel.Count);
                    empty.Add(selectPanel[rand]);

                }
                for (int j = 0; j <= empty.Count; j++)
                {

                    if (j == 0)
                    {
                        empty[0].transform.position = new Vector3(60, 240, 1.0f);
                        empty[0].SetActive(true);
                    }
                    if (j == 1)
                    {
                        empty[1].transform.position = new Vector3(285, 240, 1.0f);
                        empty[1].SetActive(true);
                    }
                }
            }
            else if (selectPanel.Count == 1) // 업그레이드할 무기가 2개 남았을때
            {
                int rand = UnityEngine.Random.Range(0, selectPanel.Count);
                empty.Add(selectPanel[rand]);
                empty[0].transform.position = new Vector3(173, 240, 1.0f);
                empty[0].SetActive(true);
            }
            else if (selectPanel.Count == 0) // 모든 무기 만렙시 코인이나 체력 올려주는 페널
            {
                for (int i = 0; i < 2; i++)
                {
                    int rand = UnityEngine.Random.Range(0, select_coin_hp.Count);
                    empty.Add(select_coin_hp[rand]);
                }
                for (int j = 0; j <= empty.Count; j++)
                {

                    if (j == 0)
                    {
                        empty[0].transform.position = new Vector3(60, 240, 1.0f);
                        empty[0].SetActive(true);
                    }
                    if (j == 1)
                    {
                        empty[1].transform.position = new Vector3(285, 240, 1.0f);
                        empty[1].SetActive(true);
                    }
                }
            }
        }
       
    }
}
