using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Player player;
    public float dmg;

    public int bulletLevel = 1;
    public bool selectedBullet = false;
    public bool level1, level2, level3, level4, level5 = true;

    Equip_Ammo _Ammo;

    ButtonManager buttonManager;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        _Ammo = GetComponent<Equip_Ammo>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        dmg = player.bulletDamage;
    }

    void Update()
    {
        levelDesign();
        bulletLevel = buttonManager.gunCount;
    }

    void levelDesign()
    {
        if (bulletLevel == 1 && level1 == true)
        {
            dmg = 3;
            Debug.Log("�Ѿ� ����");
            level1 = false;
            level2 = true;
        }
        else if (bulletLevel == 2 && level2 == true)
        {
            dmg = 6;
            level2 = false;
            level3 = true;
        }
        else if (bulletLevel == 3 && level3 == true)
        {
            dmg = 9;
            level3 = false;
            level4 = true;
        }
        else if (bulletLevel == 4 && level4 == true)
        {
            dmg = 12;
            level4 = false;
            level5 = true;
        }
        else if (bulletLevel == 5 && level5 == true && Equip_Ammo.selectedBullet == true)
        {
            dmg = 15;
            player.maxShotDelay *= 0.5f;
            level5 = false;
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
