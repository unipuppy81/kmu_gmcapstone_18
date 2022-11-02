using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_bar : MonoBehaviour
{
    Vector3 localScale;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = player.playerMaxHp;
        transform.localScale = localScale;
    }
}
