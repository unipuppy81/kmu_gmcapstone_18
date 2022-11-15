using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class exbarmanager : MonoBehaviour
{
    public float ex1Amount = 1f;
    public float ex2Amount = 2f;
    public float curEx;
    [SerializeField]
    public Slider exbar;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerEx(3);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ex")
        {
            GameObject.Find("Ex");
            curEx += ex1Amount;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Ex2")
        {
            GameObject.Find("Ex2");
            curEx += ex2Amount;
            other.gameObject.SetActive(false);
        }
    }
    public void playerEx(float maxEx)
    {
        switch(gm.levelCount)
        {
            case 0:
                exbar.value = curEx / maxEx;
                if(curEx > maxEx)
                {
                    curEx = 0;
                }
                break;
            case 1:
                maxEx = 2;
                exbar.value = curEx / maxEx;
                if (curEx > maxEx)
                {
                    curEx = 0;
                }
                break;
            case 2:
                maxEx = 3;
                exbar.value = curEx / maxEx;
                if (curEx > maxEx)
                {
                    curEx = 0;
                }
                break;
            case 3:
                maxEx = 4;
                exbar.value = curEx / maxEx;
                if (curEx == maxEx)
                {
                    curEx = 0;
                }
                break;
            case 4:
                maxEx = 5;
                exbar.value = curEx / maxEx;
                if (curEx == maxEx)
                {
                    curEx = 0;
                }
                break;
        }
    }
   
}
