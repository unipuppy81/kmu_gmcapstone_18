using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
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

    public void Start()
    {
        levelCount = 0;
        exbar.value = CurEx / MaxEx;
        levelpanel.SetActive(false);
    }
    public void Update()
    {
        ActiveFalse();
        Level();
    }
    public void Level()
    {
        if(CurEx == 3f)
        {
            levelCount++;
            playerEx(0f, 3f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if(CurEx == 5f)
        {
            levelCount++;
            playerEx(3f, 5f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 8f)
        {
            levelCount++;
            playerEx(5f, 8f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 12f)
        {
            levelCount++;
            playerEx(8f, 12f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 17f)
        {
            levelCount++;
            playerEx(12f, 17f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 23f)
        {
            levelCount++;
            playerEx(17f, 23f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 30f)
        {
            levelCount++;
            playerEx(23f, 30f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 38f)
        {
            levelCount++;
            playerEx(30f, 38f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 47f)
        {
            levelCount++;
            playerEx(38f, 47f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 57f)
        {
            levelCount++;
            playerEx(47f, 57f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 70f)
        {
            levelCount++;
            playerEx(57f, 70f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 90f)
        {
            levelCount++;
            playerEx(70f, 90f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 110f)
        {
            levelCount++;
            playerEx(70f, 110f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 130f)
        {
            levelCount++;
            playerEx(110f, 130f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 150f)
        {
            levelCount++;
            playerEx(150f, 180f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 210f)
        {
            levelCount++;
            playerEx(180f, 210f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 240f)
        {
            levelCount++;
            playerEx(210f, 240f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 270f)
        {
            levelCount++;
            playerEx(240f, 270f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 300f)
        {
            levelCount++;
            playerEx(270f, 300f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 340f)
        {
            levelCount++;
            playerEx(300f, 340f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 380f)
        {
            levelCount++;
            playerEx(340f, 380f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 420f)
        {
            levelCount++;
            playerEx(380f, 420f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 460f)
        {
            levelCount++;
            playerEx(420f, 460f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 500f)
        {
            levelCount++;
            playerEx(460f, 500f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 550f)
        {
            levelCount++;
            playerEx(500f, 550f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 600f)
        {
            levelCount++;
            playerEx(550f, 600f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 650f)
        {
            levelCount++;
            playerEx(600f, 650f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 700f)
        {
            levelCount++;
            playerEx(650f, 700f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 750f)
        {
            levelCount++;
            playerEx(700f, 750f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 800f)
        {
            levelCount++;
            playerEx(750f, 800f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 900f)
        {
            levelCount++;
            playerEx(800f, 900f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1000f)
        {
            levelCount++;
            playerEx(900f, 1000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1100f)
        {
            levelCount++;
            playerEx(1000f, 1100f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1200f)
        {
            levelCount++;
            playerEx(1100f, 1200f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1500f)
        {
            levelCount++;
            playerEx(1200f, 1500f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 1800f)
        {
            levelCount++;
            playerEx(1500f, 1800f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 2200f)
        {
            levelCount++;
            playerEx(1800f, 2200f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 2700f)
        {
            levelCount++;
            playerEx(2200f, 2700f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 3000f)
        {
            levelCount++;
            playerEx(2700f, 3000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 4000f)
        {
            levelCount++;
            playerEx(3000f, 4000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 5000f)
        {
            levelCount++;
            playerEx(4000f, 5000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 6000f)
        {
            levelCount++;
            playerEx(5000f, 6000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 7000f)
        {
            levelCount++;
            playerEx(6000f, 7000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 8000f)
        {
            levelCount++;
            playerEx(7000f, 8000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 10000f)
        {
            levelCount++;
            playerEx(8000f, 10000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 12000f)
        {
            levelCount++;
            playerEx(10000f, 12000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 14000f)
        {
            levelCount++;
            playerEx(12000f, 14000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 16000f)
        {
            levelCount++;
            playerEx(14000f, 16000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if (CurEx == 20000f)
        {
            levelCount++;
            playerEx(16000f, 20000f);
            openPanel();
            leveltext();
            RandomChoose();
        }
        else if(CurEx >= MaxEx)
        {
            levelCount = 50;
            playerEx(1200f, 1500f);
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
        }
        else if (other.gameObject.tag == "Ex2")
        {
            GameObject.Find("Ex2");
            CurEx += ex2Amount;
            Debug.Log(CurEx);
            other.gameObject.SetActive(false);
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
}
