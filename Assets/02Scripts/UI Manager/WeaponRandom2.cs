using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandom2 : MonoBehaviour
{
    [SerializeField] public GameObject[] select2;
    [SerializeField] GameObject panel;
    WeaponRandom1 array1;
    WeaponRandom3 array3;

    public bool state = false;
    public void Start()
    {
        openPanel();
    }
    public void RandomSelect()
    {
        switch (Random.Range(0, select2.Length))
        {
            case 0:
                select2[0].SetActive(true);
                array1.select1[0].SetActive(false);
                array3.select3[0].SetActive(false);
                break;
            case 1:
                select2[1].SetActive(true);
                array1.select1[1].SetActive(false);
                array3.select3[1].SetActive(false);
                break;
            case 2:
                select2[2].SetActive(true);
                array1.select1[2].SetActive(false);
                array3.select3[2].SetActive(false);
                break;
            case 3:
                select2[3].SetActive(true);
                array1.select1[3].SetActive(false);
                array3.select3[3].SetActive(false);
                break;
            case 4:
                select2[4].SetActive(true);
                array1.select1[4].SetActive(false);
                array3.select3[4].SetActive(false);
                break;
            case 5:
                select2[5].SetActive(true);
                array1.select1[5].SetActive(false);
                array3.select3[5].SetActive(false);
                break;
        }
    }
    public void openPanel()
    {
        if(panel.activeSelf == true)
        {
            RandomSelect();
        }
    }
}
