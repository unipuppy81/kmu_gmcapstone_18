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

    public float maxEx = 5f;
    public float curEx = 0f;
    public GameObject btn1;
    public GameObject levelpanel;
    public GameObject PauseBtn;
    public float _Sec;
    public int _min;
    public int _mina = 6;
    public int levelcount;
    public int min;
    public int max;

    public float ex1Amount = 1f;
    public float ex2Amount = 2f;

    Player player;

    private void Awake()
    {
        levelpanel.SetActive(false);
        player = GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
            GameObject.Find("Ex");
            curEx += ex1Amount;
            Debug.Log(curEx);
            other.gameObject.SetActive(false);
            exManager();
        }
        else if (other.gameObject.tag == "Ex2")
        {
            GameObject.Find("Ex2");
            curEx += ex2Amount;
            Debug.Log(curEx);
            other.gameObject.SetActive(false);
            exManager();
        }
    }

    void exManager()
    {
        if (curEx >= maxEx)
        {
            levelcount += 1;
            levelText.text = string.Format("LV : {0:D1}", levelcount);
            Time.timeScale = 0f;
            levelpanel.SetActive(true);
            PauseBtn.SetActive(false);
            curEx = 0f;
            maxEx += 5f;
            player.playerLevel += 1;
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
            gameObject.SetActive(false);
            timeText.text = string.Format("{0:D2}:{1:D2}", _mina, (int)_Seca);
        }
           
    }
}
