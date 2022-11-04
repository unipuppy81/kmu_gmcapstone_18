using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip_Hot7 : MonoBehaviour
{
    public int hot7Level = 0;

    public bool selectedHot7;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        InvokeRepeating("levelDesign", 5f, 5f);
        selectedHot7 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void levelDesign()
    {
        switch (hot7Level)
        {
            case 1:
                player.playercurHp *= 1.01f;
                selectedHot7 = true;
                break;

            case 2:
                player.playercurHp *= 1.02f;
                break;

            case 3:
                player.playercurHp *= 1.03f;
                break;

            case 4:
                player.playercurHp *= 1.04f;
                break;
        }
    }
}
