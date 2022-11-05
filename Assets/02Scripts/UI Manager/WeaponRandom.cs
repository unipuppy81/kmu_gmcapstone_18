using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandom : MonoBehaviour
{
    [SerializeField] GameObject[] select;
    [SerializeField] GameObject panel;
    
    public bool state = false;
    public void Start()
    {
        
    }
    public void RandomSelect()
    {
        state = false;
        for(int i = 0; i <select.Length; i++)
        {
            if(Random.Range(0,5) == i)
            {
                select[i].SetActive(true);
            }
            else
            {
                select[i].SetActive(false);
            }
        }
    }
    public void openPanel()
    {
        if(panel.activeSelf == true)
        {
            RandomSelect();
        }
        else
        {

        }
    }
}
