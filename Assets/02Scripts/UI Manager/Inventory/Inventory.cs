using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    #endregion


    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public List<InventoryItem> InvenItems = new List<InventoryItem>();

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    public int slotCnt;

    void Start()
    {
        slotCnt = 5;
    }

    public bool AddItem(InventoryItem _InventoryItem)
    {
        if(InvenItems.Count< slotCnt)
        {
            InvenItems.Add(_InventoryItem);
            if(onChangeItem != null) { }
            onChangeItem.Invoke();
            return true;
        }
    return false;
    }


    public void BtnInven()
    {
       
    }
    private void OnTriggerEnger2D(Collider2D collision)
    {
        
        if(collision.CompareTag("FieldItem")) { // 클릭 했을 때
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
            {
               
            }
        }
    }
}
