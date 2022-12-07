using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Dumbbell : MonoBehaviour  // 방패의 조합 장비
{
    Player player;
    ButtonManager buttonManager;

    public int dumbbellLevel = 0;
    public static bool selectedDumbbell = false;

    public bool level1, level2, level3, level4, level5 = true;

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
        if(dumbbellLevel >= 1)
        {
            selectedDumbbell = true;
        }
    }

    void levelDesign()
    {
        if (dumbbellLevel == 1 && level1 == true)
        {
            player.playerMaxHp *= 1.1f;
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
            level5 = true;
        }
        else if (dumbbellLevel == 5 && level5 == true)
        {
            player.playerMaxHp *= 1.4f;
            level5 = false;
        }
    }
}
