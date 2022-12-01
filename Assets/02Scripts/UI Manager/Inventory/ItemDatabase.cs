using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public Sprite[] imgSprites;

    public static ItemDatabase instance;

    private void Awake()
    {
        imgSprites = Resources.LoadAll<Sprite>("05Sprite/Equipment");
        instance = this;
    }

    public List<InventoryItem> itemDB = new List<InventoryItem>();

}
