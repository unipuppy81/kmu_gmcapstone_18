using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Ammo : MonoBehaviour
{
    public int ammoLevel = 0;

    GameManager gameManager;
    ButtonManager buttonManager;

    public static bool selectedBullet;

    public bool level1, level2, level3, level4, level5 = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        selectedBullet = false;
    }

    // Update is called once per frame
    void Update()
    {
        ammoLevel = buttonManager.ammoCount;
        //levelDesign();
        if(ammoLevel >= 1)
        {
            selectedBullet = true;
        }
    }
    /*
    void levelDesign()
    {
        if (ammoLevel == 1 && level1 == true)
        {
            gameManager.ex1Amount *= 1.05f;
            gameManager.ex2Amount *= 1.05f;
            level1 = false;
            level2 = true;
        }
        else if (ammoLevel == 2 && level2 == true)
        {
            gameManager.ex1Amount *= 1.1f;
            gameManager.ex2Amount *= 1.1f;
            level2 = false;
            level3 = true;
        }
        else if (ammoLevel == 3 && level3 == true)
        {
            gameManager.ex1Amount *= 1.15f;
            gameManager.ex2Amount *= 1.15f;
            level3 = false;
            level4 = true;
        }
        else if (ammoLevel == 4 && level4 == true)
        {
            gameManager.ex1Amount *= 1.2f;
            gameManager.ex2Amount *= 1.2f;
            level4 = false;
            level5 = true;
        }
        else if (ammoLevel == 5 && level5 == true)
        {
            gameManager.ex1Amount *= 1.25f;
            gameManager.ex2Amount *= 1.25f;
            level5 = false;
        }
    }
    */
}
