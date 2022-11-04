using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Dumbbell : MonoBehaviour  // 방패의 조합 장비
{
    Player player;

    public int dumbbellLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        levelDesign();
    }

    void levelDesign()
    {
        switch (dumbbellLevel)
        {
            case 1:
                player.playerMaxHp *= 1.1f;
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
        }
    }
}
