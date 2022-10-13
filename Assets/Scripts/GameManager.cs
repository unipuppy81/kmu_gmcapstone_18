using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float maxEx = 10f;
    public float curEx = 0f;
    public GameObject btn1;
    public GameObject levelpanel;
    public GameObject PauseBtn;

    private void Awake()
    {
        levelpanel.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
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
}
