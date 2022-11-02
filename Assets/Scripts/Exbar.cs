using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exbar : MonoBehaviour
{
    public GameManager gameManager;
    public Player player;

    [SerializeField]
    public Slider exbar;
    public Slider Hpbar;

    void Awake()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        player = gameObject.GetComponent<Player>();
    }
    void Start()
    {
        exbar.value = gameManager.curEx / gameManager.maxEx;
        Hpbar.value = player.playercurHp / player.playerMaxHp;
    }
    void Update()
    {
        playerEx();
        playerHp();
    }
    public void playerEx()
    {
        exbar.value = gameManager.curEx / gameManager.maxEx;
    }
    public void playerHp()
    {
        Hpbar.value = player.playercurHp / player.playerMaxHp;
    }
}
