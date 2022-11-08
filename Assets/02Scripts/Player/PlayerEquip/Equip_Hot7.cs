using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Equip_Hot7 : MonoBehaviour
{
    public int hot7Level = 0;
    public bool level1, level2, level3, level4, level5 = true;

    public static bool selectedHot7;

    Player player;
    ButtonManager buttonManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        InvokeRepeating("levelDesign", 5f, 5f);
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        selectedHot7 = false;
    }

    // Update is called once per frame
    void Update()
    {
        hot7Level = buttonManager.hot7Count;
        if(hot7Level >= 1)
        {
            selectedHot7 = true;
        }
    }

    void levelDesign()
    {
        if (hot7Level == 1 && level1 == true)
        {
            player.playercurHp *= 1.01f;
            level1 = false;
            level2 = true;
        }
        else if (hot7Level == 2 && level2 == true)
        {
            player.playercurHp *= 1.02f;
            level2 = false;
            level3 = true;
        }
        else if (hot7Level == 3 && level3 == true)
        {
            player.playercurHp *= 1.03f;
            level3 = false;
            level4 = true;
        }
        else if (hot7Level == 4 && level4 == true)
        {
            player.playercurHp *= 1.04f;
            level4 = false;
            level5 = true;
        }
        else if (hot7Level == 5 && level5 == true)
        {
            player.playercurHp *= 1.05f;
            level5 = false;
        }
    }
}
