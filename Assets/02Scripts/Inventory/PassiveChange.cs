using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveChange : MonoBehaviour
{
    private Image image;

    public Sprite[] sprites;
    private int index;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("05Sprite/Passive");
        image = GetComponent<Image>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            image.sprite = sprites[index];
            index++;
            if (sprites.Length == index)
            {
                index = 0;
            }
        }
    }
}