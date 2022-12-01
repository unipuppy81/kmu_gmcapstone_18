using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public SpriteRenderer image;

    public void SetItem(InventoryItem _inventoryItem)
    {
        inventoryItem.itemName = _inventoryItem.itemName;
        inventoryItem.itemImage = _inventoryItem.itemImage;
        inventoryItem.itemType = _inventoryItem.itemType;

        image.sprite = inventoryItem.itemImage;
    }

    public InventoryItem GetItem()
    {
        return inventoryItem;
    }
}
