using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelIndex : MonoBehaviour
{
    public string obj;
    public int Pindex;
   void Start()
    {
        obj = this.gameObject.name;
    }


    void Index()
    {
        //GameObject obj0 = GameObject.FindWithTag("Gun");
        //GameObject obj1 = GameObject.FindWithTag("Sheild"); 
        //GameObject obj2 = GameObject.FindWithTag("EMP");
        //GameObject obj3 = GameObject.FindWithTag("Ax");
        //GameObject obj4 = GameObject.FindWithTag("Basketball");
        //GameObject obj5 = GameObject.FindWithTag("Ammo");
        //GameObject obj6 = GameObject.FindWithTag("Dumbbell");
        //GameObject obj7 = GameObject.FindWithTag("Hot7");
        //GameObject obj8 = GameObject.FindWithTag("Bshoes");
        //GameObject obj9 = GameObject.FindWithTag("MagInc");

        if(obj == "Pan1_Gun")
        {
            Pindex = 0;
        }
        else if(obj == "Pan1_Shield")
        {
            Pindex = 1;
        }
        else if (obj == "Pan1_EMP")
        {
            Pindex = 2;
        }
        else if (obj == "Pan1_Ax")
        {
            Pindex = 3;
        }
        else if (obj == "Pan1_Basketball")
        {
            Pindex = 4;
        }
        else if (obj == "Pan1_Ammo")
        {
            Pindex = 5;
        }
        else if (obj == "Pan1_Dumbbell")
        {
            Pindex = 6;
        }
        else if (obj == "Pan1_Hot7")
        {
            Pindex = 7;
        }
        else if (obj == "Pan1_Bshoes")
        {
            Pindex = 8;
        }
        else if (obj == "Pan1_Magnetic")
        {
            Pindex = 9;
        }
    }
}
