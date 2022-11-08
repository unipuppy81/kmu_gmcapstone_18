using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exbar : MonoBehaviour
{
    public Player player;

    [SerializeField]
    public Slider Hpbar;

    void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }
    void Start()
    {
        Hpbar.value = player.playercurHp / player.playerMaxHp;
    }
    void Update()
    {
        playerHp();
    }

    public void playerHp()
    {
        Hpbar.value = player.playercurHp / player.playerMaxHp;
    }
}
