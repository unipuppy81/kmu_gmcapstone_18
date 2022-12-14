using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Spinach : MonoBehaviour
{
    Player player;
    ButtonManager buttonManager;

    public int spinachLevel = 0;

    static public int ppoppaiLevel;

    public bool level1, level2, level3, level4, level5 = true;

    void Start()
    {
        player = GetComponent<Player>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }


    void Update()
    {
        levelDesign();
        spinachLevel = buttonManager.ppoppaiCount;
    }

    

    void levelDesign()
    {
        if (spinachLevel == 1 && level1 == true)
        {
            ppoppaiLevel = 1;
            level1 = false;
            level2 = true;
        }
        else if (spinachLevel == 2 && level2 == true)
        {
            ppoppaiLevel = 2;
            level2 = false;
            level3 = true;
        }
        else if (spinachLevel == 3 && level3 == true)
        {
            ppoppaiLevel = 3;
            level3 = false;
            level4 = true;
        }
        else if (spinachLevel == 4 && level4 == true)
        {
            ppoppaiLevel = 4;
            level4 = false;
            level5 = true;
        }
        else if (spinachLevel == 5 && level5 == true)
        {
            ppoppaiLevel = 5;
            level5 = false;
        }
    }
}
