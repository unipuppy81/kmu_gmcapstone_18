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
    TextMeshProUGUI levelText;
    [SerializeField]
    public List<GameObject> select1 = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select2 = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select3 = new List<GameObject>();

    public float maxEx = 5f;
    public float curEx = 0f;
    public GameObject levelpanel;
    public GameObject PauseBtn;
    public float _Sec;
    public int _min;
    public int _mina = 6;
    public int levelcount;
    public int min;
    public int max;
    int i, j, k;

    public float ex1Amount = 1f;
    public float ex2Amount = 2f;

    Player player;

    private void Awake()
    {
        levelpanel.SetActive(false);
        player = GetComponent<Player>();
    }
    private void Update()
    {
        Timer();
        ActiveFalse();
    }

    void ActiveFalse()
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
            GameObject.Find("Ex");
            curEx += ex1Amount;
            other.gameObject.SetActive(false);
            exManager();
        }
        else if (other.gameObject.tag == "Ex2")
        {
            GameObject.Find("Ex2");
            curEx += ex2Amount;
            other.gameObject.SetActive(false);
            exManager();
        }
    }

    void exManager()
    {
        if (curEx == maxEx)
        {
            levelcount += 1;
            levelText.text = string.Format("LV : {0:D1}", levelcount);
            Time.timeScale = 0f;
            levelpanel.SetActive(true);
            RandomSelect1();
            PauseBtn.SetActive(false);
            curEx = 0f;
            //maxEx += 5f;
            player.playerLevel += 1;
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

    public void RandomSelect1()
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

}
