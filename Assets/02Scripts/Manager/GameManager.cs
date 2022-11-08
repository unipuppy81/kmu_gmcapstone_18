using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

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
    public int levelcount;
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
        if(CurEx < 3)
        {
            playerEx(0f, 2f);
        }
        if (CurEx == 3f)
        {
            levelCount++;
            playerEx(0f, 2f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 5f)
        {
            levelCount++;
            playerEx(0f, 3f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 8f)
        {
            levelCount++;
            playerEx(0f, 4f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 12f)
        {
            levelCount++;
            playerEx(0f, 5f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 17f)
        {
            levelCount++;
            playerEx(0f, 6f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 23f)
        {
            levelCount++;
            playerEx(0f, 7f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 30f)
        {
            levelCount++;
            playerEx(0f, 88f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 38f)
        {
            levelCount++;
            playerEx(0f, 9f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 47f)
        {
            levelCount++;
            playerEx(0f, 10f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 57f)
        {
            levelCount++;
            playerEx(0f, 13f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 70f)
        {
            levelCount++;
            playerEx(0f, 20f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 90f)
        {
            levelCount++;
            playerEx(0f, 20f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 110f)
        {
            levelCount++;
            playerEx(0f, 20f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 130f)
        {
            levelCount++;
            playerEx(0f, 20f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 150f)
        {
            levelCount++;
            playerEx(0f, 30f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 210f)
        {
            levelCount++;
            playerEx(0f, 30f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 240f)
        {
            levelCount++;
            playerEx(0f, 30f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 270f)
        {
            levelCount++;
            playerEx(0f, 30f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 300f)
        {
            levelCount++;
            playerEx(0f, 40f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 340f)
        {
            levelCount++;
            playerEx(0f, 40f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 380f)
        {
            levelCount++;
            playerEx(0f, 40f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 420f)
        {
            levelCount++;
            playerEx(0f, 40f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 460f)
        {
            levelCount++;
            playerEx(0f, 40f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 500f)
        {
            levelCount++;
            playerEx(0f, 50f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 550f)
        {
            levelCount++;
            playerEx(0f, 50f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 600f)
        {
            levelCount++;
            playerEx(0f, 50f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 650f)
        {
            levelCount++;
            playerEx(0f, 50f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 700f)
        {
            levelCount++;
            playerEx(0f, 50f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 750f)
        {
            levelCount++;
            playerEx(0f, 50f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 800f)
        {
            levelCount++;
            playerEx(0f, 100f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 900f)
        {
            levelCount++;
            playerEx(0f, 100f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1000f)
        {
            levelCount++;
            playerEx(0f, 100f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1100f)
        {
            levelCount++;
            playerEx(0f, 100f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1200f)
        {
            levelCount++;
            playerEx(0f, 300f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1500f)
        {
            levelCount++;
            playerEx(0f, 300f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1800f)
        {
            levelCount++;
            playerEx(0f, 300f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 2200f)
        {
            levelCount++;
            playerEx(0f, 300f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 2700f)
        {
            levelCount++;
            playerEx(0f, 300f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 3000f)
        {
            levelCount++;
            playerEx(0f, 1000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 4000f)
        {
            levelCount++;
            playerEx(0f, 1000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 5000f)
        {
            levelCount++;
            playerEx(0f, 1000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 6000f)
        {
            levelCount++;
            playerEx(0f, 1000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 7000f)
        {
            levelCount++;
            playerEx(0f, 1000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 8000f)
        {
            levelCount++;
            playerEx(0f, 2000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 10000f)
        {
            levelCount++;
            playerEx(0f, 2000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 12000f)
        {
            levelCount++;
            playerEx(0f, 2000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 14000f)
        {
            levelCount++;
            playerEx(0f, 2000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 16000f)
        {
            levelCount++;
            playerEx(0f, 4000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 20000f)
        {
            levelCount++;
            playerEx(2000f, 2000f);
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
    public void playerEx(float curEx, float maxEx)
    {
        exbar.value = curEx / maxEx;
    }
    public void RandomChoose()
    {
        if (levelpanel.activeSelf == true)
        {
            i = Random.Range(0, select1.Count);
            switch (i)
            {
                case 0:
                    select1[0].SetActive(true);
                    j = Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = Random.Range(0, select3.Count);
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 1:
                    select1[1].SetActive(true);
                    j = Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = Random.Range(0, select3.Count);
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 2:
                    select1[2].SetActive(true);
                    j = Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = Random.Range(0, select3.Count);
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 3:
                    select1[3].SetActive(true);
                    j = Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = Random.Range(0, select3.Count);
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 4:
                    select1[4].SetActive(true);
                    j = Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = Random.Range(0, select3.Count);
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    select3[k].SetActive(true);
                    break;
                case 5:
                    select1[5].SetActive(true);
                    j = Random.Range(0, select2.Count);
                    while (i == j)
                    {
                        j = Random.Range(0, select2.Count);
                    }
                    select2[j].SetActive(true);
                    k = Random.Range(0, select3.Count);
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == j)
                    {
                        k = Random.Range(0, select3.Count);
                    }
                    while (k == i)
                    {
                        k = Random.Range(0, select3.Count);
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
