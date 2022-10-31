using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public float maxEx = 5f;
    public float curEx = 0f;
    public GameObject btn1;
    public GameObject levelpanel;
    public GameObject PauseBtn;
    public float _Sec;
    public int _min;
    public int _mina;
    [SerializeField]
    TextMeshProUGUI timeText;

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
                levelpanel.SetActive(true);
                PauseBtn.SetActive(false);
                curEx = 0f;
                maxEx += 5f;
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

        if((int)_Sec >59)
        {
            _Sec = 0;
            _min++;
        }
        if (_min == 1)
        {
            _mina = 1;
            float _Seca = 0.0f;
            timeText.text = string.Format("{0:D2}:{1:D2}", _mina, (int)_Seca);
        }
           
    }
}
