using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_MagInc : MonoBehaviour
{
    Player player;
    ButtonManager buttonManager;

    public int magnetInclLevel = 0;
    public static bool selectedMagnetInc = false;

    public bool level1, level2, level3, level4, level5 = true;


    void Start()
    {
        player = GetComponent<Player>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }


    void Update()
    {
        levelDesign();
        magnetInclLevel = buttonManager.magincCount;
        if (magnetInclLevel >= 1)
        {
            selectedMagnetInc = true;
        }
    }

    void levelDesign()
    {
        if (magnetInclLevel == 1 && level1 == true)
        {
            transform.localScale = new Vector3(0.06f, 0.06f, 1f);
            level1 = false;
            level2 = true;
        }
        else if (magnetInclLevel == 2 && level2 == true)
        {
            transform.localScale = new Vector3(0.08f, 0.08f, 1f);
            level2 = false;
            level3 = true;
        }
        else if (magnetInclLevel == 3 && level3 == true)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1f);
            level3 = false;
            level4 = true;
        }
        else if (magnetInclLevel == 4 && level4 == true)
        {
            transform.localScale = new Vector3(0.13f, 0.13f, 1f);
            level4 = false;
            level5 = true;
        }
        else if (magnetInclLevel == 5 && level5 == true)
        {
            transform.localScale = new Vector3(0.15f, 0.15f, 1f);
            level5 = false;
        }
    }
}
