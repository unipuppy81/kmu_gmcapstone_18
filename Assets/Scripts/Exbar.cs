using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exbar : MonoBehaviour
{
    public GameManager gameManager;
    public Image exbar;

    void Update()
    {
        
    }
    public void playerEx()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        exbar.fillAmount = gameManager.maxEx / gameManager.curEx;
    }
}
