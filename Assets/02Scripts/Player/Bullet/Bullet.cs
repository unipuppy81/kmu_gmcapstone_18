using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Player player;
    public float dmg;
    public float lifetime;

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
        alive();
    }

    void alive()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= 3.0f)
        {
            gameObject.SetActive(false);
            lifetime = 0f;
        }
    }
    void levelDesign()
    {
        if (bulletLevel == 1 && level1 == true)
        {
            dmg = 2;
            player.spawntime = 0.4f;
            level1 = false;
            level2 = true;
        }
        else if (bulletLevel == 2 && level2 == true)
        {
            dmg = 2;
            player.bulletSpeed = 5f;
            level2 = false;
            level3 = true;
        }
        else if (bulletLevel == 3 && level3 == true)
        {
            dmg = 3;
            player.spawntime = 0.35f;
            level3 = false;
            level4 = true;
        }
        else if (bulletLevel == 4 && level4 == true)
        {
            dmg = 3;
            player.bulletSpeed = 7f;
            level4 = false;
            level5 = true;
        }
        else if (bulletLevel == 5 && level5 == true && Equip_Ammo.selectedBullet == true)
        {
            dmg = 4;
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
