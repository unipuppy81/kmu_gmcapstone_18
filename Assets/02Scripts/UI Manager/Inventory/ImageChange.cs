using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{

    public Sprite[] imgSprites;

    private int index; 
    public Sprite change_img;
    private Image image;

    void Start()
    {
        index = 2;
        imgSprites = Resources.LoadAll<Sprite>("05Sprite/Equipment");
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            image.sprite = imgSprites[index];
            UnityEngine.Debug.Log(index);
            index++;
            UnityEngine.Debug.Log(index);
            if (imgSprites.Length == index)
            {
                index = 0;
            }
        }
    }
}
