using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exbar : MonoBehaviour
{
    public Player player;
    public GameManager gm;

    [SerializeField]
    public Slider Hpbar;
    [SerializeField]
    public Slider exbar;
    void Awake()
    {
        player = gameObject.GetComponent<Player>();
        gm = gameObject.GetComponent<GameManager>();
    }
    void Start()
    {
        Hpbar.value = player.playercurHp / player.playerMaxHp;
        exbar.value = gm.CurEx / gm.MaxEx;
    }
    void Update()
    {
        playerHp();
    }

    public void playerHp()
    {
        Hpbar.value = player.playercurHp / player.playerMaxHp;
        exbar.value = gm.CurEx / gm.MaxEx;
    }
}
