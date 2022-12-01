using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public InventoryItem inventoryItem;
    public Image itemIcon;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = inventoryItem.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        inventoryItem = null;
        itemIcon.gameObject.SetActive(false);
    }
}
