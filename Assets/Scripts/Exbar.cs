using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exbar : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    public Slider exbar;

    void Awake()
    {
        gameManager = gameObject.GetComponent<GameManager>();
    }
    void Start()
    {
        exbar.value = gameManager.curEx / gameManager.maxEx;
    }
    void Update()
    {
        playerEx();
    }
    public void playerEx()
    {
        exbar.value = gameManager.curEx / gameManager.maxEx;
    }
}
