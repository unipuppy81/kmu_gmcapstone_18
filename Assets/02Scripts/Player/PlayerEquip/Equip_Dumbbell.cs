using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Equip_Dumbbell : MonoBehaviour  // 방패의 조합 장비
{
    Player player;
    ButtonManager buttonManager;

    public int dumbbellLevel = 0;

    public bool selectedDumbbell = false;

    public bool level1, level2, level3, level4 = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        levelDesign();
        dumbbellLevel = buttonManager.dumbbellCount;
    }

    void levelDesign()
    {
        if (dumbbellLevel == 1 && level1 == true)
        {
            player.playerMaxHp *= 1.1f;
            selectedDumbbell = true;
            level1 = false;
            level2 = true;
        }
        else if (dumbbellLevel == 2 && level2 == true)
        {
            player.playerMaxHp *= 1.2f;
            level2 = false;
            level3 = true;
        }
        else if (dumbbellLevel == 3 && level3 == true)
        {
            player.playerMaxHp *= 1.3f;
            level3 = false;
            level4 = true;
        }
        else if (dumbbellLevel == 4 && level4 == true)
        {
            player.playerMaxHp *= 1.4f;
            level4 = false;
        }
        /*switch (dumbbellLevel)
        {
            case 1:
                player.playerMaxHp *= 1.1f;
                selectedDumbbell = true;
                break;

            case 2:
                player.playerMaxHp *= 1.2f;
                break;

            case 3:
                player.playerMaxHp *= 1.3f;
                break;

            case 4:
                player.playerMaxHp *= 1.4f;
                break;
        }*/
    }
}
