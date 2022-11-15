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

    public float MaxEx = 20000.0f;
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
        levelpanel.SetActive(false);
    }



    private void Update()
    {

        Timer();
        ActiveFalse();
    }



    public void Level()
    {
        if (CurEx == 3f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 5f)
        {
            levelCount++;

            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 8f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 12f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 17f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 23f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 30f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 38f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 47f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 57f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 70f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 90f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 110f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 130f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 150f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 210f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 240f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 270f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 300f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 340f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 380f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 420f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 460f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 500f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 550f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 600f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 650f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 700f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 750f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 800f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 900f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1100f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1200f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1500f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1800f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 2200f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 2700f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 3000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 4000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 5000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 6000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 7000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 8000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 10000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 12000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 14000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 16000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 20000f)
        {
            levelCount++;
            openPanel();
            leveltext();
            RandomChoose();
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
                    while (k == i)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                        while (k == i)
                        {
                            k = UnityEngine.Random.Range(0, select3.Count);
                        }
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
                    while (k == i)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                        while (k == i)
                        {
                            k = UnityEngine.Random.Range(0, select3.Count);
                        }
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
                    while (k == i)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                        while (k == i)
                        {
                            k = UnityEngine.Random.Range(0, select3.Count);
                        }
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
                    while (k == i)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                        while (k == i)
                        {
                            k = UnityEngine.Random.Range(0, select3.Count);
                        }
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
                    while (k == i)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                        while (k == i)
                        {
                            k = UnityEngine.Random.Range(0, select3.Count);
                        }
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
                    while (k == i)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = UnityEngine.Random.Range(0, select3.Count);
                        while (k == i)
                        {
                            k = UnityEngine.Random.Range(0, select3.Count);
                        }
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
