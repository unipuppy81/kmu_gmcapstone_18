using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

[System.Serializable]  // ����ȭ

public class Item
{
    public Item(string _Type, string _Name, string _Explain, string _Number, bool _isUsing, string _Index)
    {
        Type = _Type; Name = _Name; Explain = _Explain; Number = _Number; isUsing= _isUsing; Index = _Index;
    }

    public string Type, Name, Explain, Number, Index;
    public bool isUsing;
}


public class ItemDB : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item> AllItemList, MyItemList, CurItemList;
    public string curType = "Equipment";
    public string curName = "Gun01";
    public GameObject[] EquipSlot, PassiveSlot, UsingImage;
    public Image[] ItemImage;
    public Sprite[] ItemSprite;

    int count = 0;
    void Start()
    {
        // ��ü ������ ����Ʈ �ҷ���
        ItemSprite = Resources.LoadAll<Sprite>("05Sprite/Equipment");
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
       
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4] == "TRUE", row[5]));
        }

        //StartItem();
        Load();

    }

    public void TabClick(string tabName)
    {
        /*
        // ���� ������ ����Ʈ�� Ŭ���� Ÿ�Ը� �߰�
        curType = tabName;
        //CurItemList = MyItemList.FindAll(x => x.Type == tabName);
        CurItemList = AllItemList.FindAll(x => x.Type == tabName);
        
        for (int i = 0; i < EquipSlot.Length; i++)
        {
            // ���԰� �ؽ�Ʈ ���̱�
            bool isExist = i < CurItemList.Count;

            EquipSlot[i].SetActive(isExist);
            //EquipSlot[i].GetComponentInChildren<Text>().text = i < CurItemList.Count ? CurItemList[i].Name : "";

            if (isExist)
            {
                ItemImage[i].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == CurItemList[i].Name)];
            }
        }
        */
    }

    public void AddEquip(string EquipName)
    {
        Item AddItem, CompareItem;
        curName = EquipName;

        bool canExist;

        AddItem = AllItemList.Find(x => x.Name == EquipName);
        CurItemList.Add(AddItem);

        int spriteNum = int.Parse(CurItemList[count].Index);
        UnityEngine.Debug.Log("spritenum");
        UnityEngine.Debug.Log(spriteNum);
        if (count < EquipSlot.Length)
        {
            bool isExist = count < EquipSlot.Length;

            EquipSlot[count].SetActive(isExist);

            if (isExist)
            {
                ItemImage[count].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == AllItemList[spriteNum].Name)];
            }
            count++;

        }
        


    } 

    //public void GetItemClick()
    //{
    //    Item curItem = MyItemList.Find(x => x.Name == ItemNameInput.text);
    //    if(curItem != null)
    //    {
    //        curItem.Number = (int.Parse(curItem.Number) + int.Parse(ItemNumberInput.text)).ToString();
    //    }
    //    Save();

    //}

    public void StartItem()
    {
        Item BasicItem = AllItemList.Find(x => x.Name == "Gun01");
        MyItemList = new List<Item>() { BasicItem };
        //Save();
    }

    public void SlotClick(int slotNum)
    {
        /*
        Item CurItem = CurItemList[slotNum];
        Item UsingItem = CurItemList.Find(x => x.isUsing == true);

        if(curType == "Equipment")
        {
            if (UsingItem != null) UsingItem.isUsing = false;
            CurItem.isUsing = true;
        }
        else
        {
            CurItem.isUsing = !CurItem.isUsing;
            if (UsingItem != null) UsingItem.isUsing = false;

        }

        Save();
        */
    }



    void Save()
    {
        string jdata = JsonConvert.SerializeObject(MyItemList); // jsonconvert list->string
        File.WriteAllText(Application.dataPath + "/Resources/MyItemText.txt", jdata);

        TabClick(curType);
    }

    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Resources/MyItemText.txt");
        MyItemList = JsonConvert.DeserializeObject<List<Item>>(jdata); // ������ȭ string->list

        TabClick(curType);
    }
}
