using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Ammo : MonoBehaviour
{
    public int ammoLevel = 0;

    GameManager gameManager;

    public bool selectedBullet;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        selectedBullet = false;
    }

    // Update is called once per frame
    void Update()
    {
        levelDesign();
    }
    void levelDesign()
    {
        switch (ammoLevel)
        {
            case 1:
                gameManager.ex1Amount *= 1.05f;
                gameManager.ex2Amount *= 1.05f;
                selectedBullet = true;
                break;

            case 2:
                gameManager.ex1Amount *= 1.1f;
                gameManager.ex2Amount *= 1.1f;
                break;

            case 3:
                gameManager.ex1Amount *= 1.15f;
                gameManager.ex2Amount *= 1.15f;
                break;

            case 4:
                gameManager.ex1Amount *= 1.2f;
                gameManager.ex2Amount *= 1.2f;
                break;
        }
    }
}
