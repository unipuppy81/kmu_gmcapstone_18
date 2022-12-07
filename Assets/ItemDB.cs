using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

[System.Serializable]  // 직렬화

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
    bool canExist = true;
    int count = 0;

    void Start()
    {
        // 전체 아이템 리스트 불러옴
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
        // 현재 아이템 리스트에 클릭한 타입만 추가
        curType = tabName;
        //CurItemList = MyItemList.FindAll(x => x.Type == tabName);
        CurItemList = AllItemList.FindAll(x => x.Type == tabName);
        
        for (int i = 0; i < EquipSlot.Length; i++)
        {
            // 슬롯과 텍스트 보이기
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
        Item AddItem, CompareItem, CompareItem1, CompareItem2, CompareItem3;
        curName = EquipName;

        AddItem = AllItemList.Find(x => x.Name == EquipName);
        AddItem.isUsing = true;
        int a = count - 1;
        int i = 0;

        
        if (CurItemList.Count > 0)
        {
            if(CurItemList.Count == 1) { 
                CompareItem = CurItemList[0];

                int num1 = int.Parse(AddItem.Index);
                int num2 = int.Parse(CompareItem.Index);

                if (num1 == num2)
                {
                    canExist = false;
                    UnityEngine.Debug.Log("A");
                    UnityEngine.Debug.Log(canExist);
                }
                else
                {
                    canExist = true;
                    UnityEngine.Debug.Log("B");
                    UnityEngine.Debug.Log(canExist);
                }
            }
            else if (CurItemList.Count == 2)
            {
                CompareItem = CurItemList[0];
                CompareItem1 = CurItemList[1];

                int num1 = int.Parse(AddItem.Index);
                int num2 = int.Parse(CompareItem.Index);
                int num3 = int.Parse(CompareItem1.Index);


                if (num1 == num2 || num1 == num3)
                {
                    canExist = false;
                    UnityEngine.Debug.Log("C");
                    UnityEngine.Debug.Log(canExist);
                }
                else
                {
                    canExist = true;
                    UnityEngine.Debug.Log("D");
                    UnityEngine.Debug.Log(canExist);
                }
            }
            else if (CurItemList.Count == 3)
            {
                CompareItem = CurItemList[0];
                CompareItem1 = CurItemList[1];
                CompareItem2 = CurItemList[2];

                int num1 = int.Parse(AddItem.Index);
                int num2 = int.Parse(CompareItem.Index);
                int num3 = int.Parse(CompareItem1.Index);
                int num4 = int.Parse(CompareItem2.Index);

                if (num1 == num2 || num1 == num3 || num1 == num4)
                {
                    canExist = false;
                    UnityEngine.Debug.Log("E");
                    UnityEngine.Debug.Log(canExist);
                }
                else
                {
                    canExist = true;
                    UnityEngine.Debug.Log("F");
                    UnityEngine.Debug.Log(canExist);
                }
            }
            else if (CurItemList.Count == 4)
            {
                CompareItem = CurItemList[0];
                CompareItem1 = CurItemList[1];
                CompareItem2 = CurItemList[2];
                CompareItem3 = CurItemList[3];

                int num1 = int.Parse(AddItem.Index);
                int num2 = int.Parse(CompareItem.Index);
                int num3 = int.Parse(CompareItem1.Index);
                int num4 = int.Parse(CompareItem2.Index);
                int num5 =  int.Parse(CompareItem3.Index);

                if (num1 == num2 || num1 == num3 || num1 == num4 || num1 == num5)
                {
                    canExist = false;
                    UnityEngine.Debug.Log("G");
                    UnityEngine.Debug.Log(canExist);
                }
                else
                {
                    canExist = true;
                    UnityEngine.Debug.Log("H");
                    UnityEngine.Debug.Log(canExist);
                }
            }
        }

        if (canExist == true) {
            CurItemList.Add(AddItem);
            
            UnityEngine.Debug.Log("AddItem");

            int spriteNum = int.Parse(CurItemList[count].Index);

            if (count < EquipSlot.Length)
            {
                 bool isExist = count < EquipSlot.Length;

                EquipSlot[count].SetActive(isExist);

                UnityEngine.Debug.Log("생성");
                if (isExist)
                {
                    ItemImage[count].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == AllItemList[spriteNum].Name)];
                }
                count++;
            }
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
        MyItemList = JsonConvert.DeserializeObject<List<Item>>(jdata); // 역직렬화 string->list

        TabClick(curType);
    }
}
