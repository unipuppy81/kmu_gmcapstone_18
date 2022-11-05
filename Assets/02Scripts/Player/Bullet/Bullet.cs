using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite[] Gun;
    private Player player;
    public float dmg;

    public int bulletLevel = 1;
    public bool selectedBullet;

    Equip_Ammo _Ammo;

    void Awake()
    {

    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        _Ammo = GetComponent<Equip_Ammo>();
        selectedBullet = false;

        dmg = player.bulletDamage;
    }

    void Update()
    {
        levelDesign();
    }

    void levelDesign()
    {
        switch (bulletLevel)
        {
            case 1:
                dmg = 3;
                selectedBullet = true;
                break;

            case 2:
                dmg = 6;
                break;

            case 3:
                dmg = 9;
                break;

            case 4:
                dmg = 12;
                break;
        }
        if(bulletLevel == 5 && _Ammo.selectedBullet == true)
        {
            dmg = 15;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy01")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Boss")
        {
            gameObject.SetActive(false);
        }
    }

}
