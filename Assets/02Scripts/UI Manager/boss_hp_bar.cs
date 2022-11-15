using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_hp_bar : MonoBehaviour
{

    [SerializeField]
    public Slider Hpbar;

    void Awake()
    {

    }
    void Start()
    {
        Hpbar.value = Boss.bossCurHealth / Boss.bossHealth;
    }
    void Update()
    {
        playerHp();
    }

    public void playerHp()
    {
        Hpbar.value = Boss.bossCurHealth / Boss.bossHealth;
    }
}
