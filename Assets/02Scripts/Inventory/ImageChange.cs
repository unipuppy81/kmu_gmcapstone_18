using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    private Image image;

    public Sprite[] sprites;
    private int index;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("05Sprite/Equipment");
        image = GetComponent<Image>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            image.sprite = sprites[index];
            index++;
            if (sprites.Length == index) {
                index = 0;
            }
        }
    }
}
