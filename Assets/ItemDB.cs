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

// Item == Equipment

public class ItemDB : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item> AllItemList, MyItemList, CurItemList, CurPassiveList;
    public string curType = "Equipment";
    public string curName = "Gun01";
    public GameObject[] EquipSlot, PassiveSlot, UsingImage;
    public Image[] ItemImage, PassiveImage;
    public Sprite[] ItemSprite, PassiveSprite;
    bool canExist = true;
    int Equipcount = 0;
    int Passivecount = 0;

    void Start()
    {
        // 전체 아이템 리스트 불러옴
        ItemSprite = Resources.LoadAll<Sprite>("05Sprite/Equipment");
        PassiveSprite = Resources.LoadAll<Sprite>("05Sprite/Passive");
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
      
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4] == "TRUE", row[5]));
        }

        StartEqiup();
        Load();

    }

    public void StartEqiup()
    {
        // 조건주고 캐릭터마다 무기 골라넣기
        AddEquip("Gun01");
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
        int a = Equipcount - 1;
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

            int spriteNum = int.Parse(CurItemList[Equipcount].Index);

            if (Equipcount < EquipSlot.Length)
            {
                 bool isExist = Equipcount < EquipSlot.Length;

                EquipSlot[Equipcount].SetActive(isExist);

                UnityEngine.Debug.Log("생성");
                if (isExist)
                {
                    ItemImage[Equipcount].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == AllItemList[spriteNum].Name)];
                }
                Equipcount++;
            }
        }
    }
    
    public void AddPassive(string PassiveName)
    {
        Item AddPassive, CompareItem, CompareItem1, CompareItem2, CompareItem3;
        curName = PassiveName;

        AddPassive = AllItemList.Find(x => x.Name == PassiveName);
        AddPassive.isUsing = true;
        int a = Passivecount - 1;
        int i = 0;


        if (CurPassiveList.Count > 0)
        {
            if (CurPassiveList.Count == 1)
            {
                CompareItem = CurPassiveList[0];

                int num1 = int.Parse(AddPassive.Index);
                int num2 = int.Parse(CompareItem.Index);

                if (num1 == num2)
                {
                    canExist = false;
                }
                else
                {
                    canExist = true;
                }
            }
            else if (CurPassiveList.Count == 2)
            {
                CompareItem = CurPassiveList[0];
                CompareItem1 = CurPassiveList[1];

                int num1 = int.Parse(AddPassive.Index);
                int num2 = int.Parse(CompareItem.Index);
                int num3 = int.Parse(CompareItem1.Index);


                if (num1 == num2 || num1 == num3)
                {
                    canExist = false;
                }
                else
                {
                    canExist = true;
                }
            }
            else if (CurPassiveList.Count == 3)
            {
                CompareItem = CurPassiveList[0];
                CompareItem1 = CurPassiveList[1];
                CompareItem2 = CurPassiveList[2];

                int num1 = int.Parse(AddPassive.Index);
                int num2 = int.Parse(CompareItem.Index);
                int num3 = int.Parse(CompareItem1.Index);
                int num4 = int.Parse(CompareItem2.Index);

                if (num1 == num2 || num1 == num3 || num1 == num4)
                {
                    canExist = false;
                }
                else
                {
                    canExist = true;
                }
            }
            else if (CurPassiveList.Count == 4)
            {
                CompareItem = CurItemList[0];
                CompareItem1 = CurPassiveList[1];
                CompareItem2 = CurPassiveList[2];
                CompareItem3 = CurPassiveList[3];

                int num1 = int.Parse(AddPassive.Index);
                int num2 = int.Parse(CompareItem.Index);
                int num3 = int.Parse(CompareItem1.Index);
                int num4 = int.Parse(CompareItem2.Index);
                int num5 = int.Parse(CompareItem3.Index);

                if (num1 == num2 || num1 == num3 || num1 == num4 || num1 == num5)
                {
                    canExist = false;
                }
                else
                {
                    canExist = true;
                }
            }
        }

        if (canExist == true)
        {
            CurPassiveList.Add(AddPassive);

            int spriteNum = int.Parse(CurPassiveList[Passivecount].Index);
            UnityEngine.Debug.Log(spriteNum);
            UnityEngine.Debug.Log("ABC");
            if (Passivecount < PassiveSlot.Length)
            {
                bool isExist = Passivecount < PassiveSlot.Length;

                PassiveSlot[Passivecount].SetActive(isExist);

                if (isExist)
                {
                    PassiveImage[Passivecount].sprite = PassiveSprite[AllItemList.FindIndex(x => x.Name == AllItemList[spriteNum].Name)];
                }
                Passivecount++;
            }
        }
    }
    
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
