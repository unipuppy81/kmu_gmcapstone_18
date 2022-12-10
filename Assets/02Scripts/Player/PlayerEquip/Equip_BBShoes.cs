using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_BBShoes : MonoBehaviour
{
    Player player;
    ButtonManager buttonManager;

    public int bbshoeslLevel = 0;
    public static bool selectedBBShoes = false;

    public bool level1, level2, level3, level4, level5 = true;

    void Start()
    {
        player = GetComponent<Player>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }


    void Update()
    {
        levelDesign();
        bbshoeslLevel = buttonManager.bshoesCount;
        if (bbshoeslLevel >= 1)
        {
            selectedBBShoes = true;
        }
    }

    void levelDesign()
    {
        if (bbshoeslLevel == 1 && level1 == true)
        {
            player.playerSpeed += 0.3f;
            level1 = false;
            level2 = true;
        }
        else if (bbshoeslLevel == 2 && level2 == true)
        {
            player.playerSpeed += 0.3f;
            level2 = false;
            level3 = true;
        }
        else if (bbshoeslLevel == 3 && level3 == true)
        {
            player.playerSpeed += 0.3f;
            level3 = false;
            level4 = true;
        }
        else if (bbshoeslLevel == 4 && level4 == true)
        {
            player.playerSpeed += 0.3f;
            level4 = false;
            level5 = true;
        }
        else if (bbshoeslLevel == 5 && level5 == true)
        {
            player.playerSpeed += 0.3f;
            level5 = false;
        }
    }
}
