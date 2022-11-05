using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandom1 : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> select1 = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select2 = new List<GameObject>();
    [SerializeField]
    public List<GameObject> select3 = new List<GameObject>();

    [SerializeField] GameObject panel;

    int i;
    int j;
    int k;

    public bool state = false;
    public void Start()
    {
        openPanel();
    }
    public void RandomSelect1()
    {
        i = Random.Range(0, select1.Count);
        switch (i)
        {
            case 0:
                select1[0].SetActive(true);
                select2.RemoveAt(i);
                j = Random.Range(0, select2.Count);
                select2[j].SetActive(true);
                select3.RemoveAt(j);
                select3.RemoveAt(i);
                k = Random.Range(0, select3.Count);
                select3[k].SetActive(true);
                break;
            case 1:
                select1[1].SetActive(true);
                select2.RemoveAt(i);
                j = Random.Range(0, select2.Count);
                select2[j].SetActive(true);
                select3.RemoveAt(j);
                select3.RemoveAt(i);
                k = Random.Range(0, select3.Count);
                select3[k].SetActive(true);
                break;
            case 2:
                select1[2].SetActive(true);
                select2.RemoveAt(i);
                j = Random.Range(0, select2.Count);
                select2[j].SetActive(true);
                select3.RemoveAt(j);
                select3.RemoveAt(i);
                k = Random.Range(0, select3.Count);
                select3[k].SetActive(true);
                break;
            case 3:
                select1[3].SetActive(true);
                select2.RemoveAt(i);
                j = Random.Range(0, select2.Count);
                select2[j].SetActive(true);
                select3.RemoveAt(j);
                select3.RemoveAt(i);
                k = Random.Range(0, select3.Count);
                select3[k].SetActive(true);
                break;
            case 4:
                select1[4].SetActive(true);
                select2.RemoveAt(i);
                j = Random.Range(0, select2.Count);
                select2[j].SetActive(true);
                select3.RemoveAt(j);
                select3.RemoveAt(i);
                k = Random.Range(0, select3.Count);
                select3[k].SetActive(true);
                break;
            case 5:
                select1[5].SetActive(true);
                select2.RemoveAt(i);
                j = Random.Range(0, select2.Count);
                select2[j].SetActive(true);
                select3.RemoveAt(j);
                select3.RemoveAt(i);
                k = Random.Range(0, select3.Count);
                select3[k].SetActive(true);
                break;
        }
    }

    public void openPanel()
    {
        if (panel.activeSelf == true)
        {
            RandomSelect1();
        }
    }
}
