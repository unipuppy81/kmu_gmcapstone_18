using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Equip_Armor : MonoBehaviour
{
    Player player;
    ButtonManager buttonManager;
    Enemy enemy;

    public int armorLevel = 0;

    public bool level1, level2, level3, level4, level5 = true;

    void Start()
    {
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
        buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }


    void Update()
    {
        levelDesign();
        armorLevel = buttonManager.armorCount;
    }

    void levelDesign()
    {
        if (armorLevel == 1 && level1 == true)
        {
            if(enemy.enemyType == Enemy.Type.A)
            {
                enemy.enemyDamage *= 0.95f;
            }
            else if(enemy.enemyType == Enemy.Type.B)
            {
                enemy.enemyDamage *= 0.95f;
            }
            else if(enemy.enemyType == Enemy.Type.C)
            {
                enemy.enemyDamage *= 0.95f;
            }
            level1 = false;
            level2 = true;
        }
        else if (armorLevel == 2 && level2 == true)
        {
            if (enemy.enemyType == Enemy.Type.A)
            {
                enemy.enemyDamage *= 0.90f;
            }
            else if (enemy.enemyType == Enemy.Type.B)
            {
                enemy.enemyDamage *= 0.90f;
            }
            else if (enemy.enemyType == Enemy.Type.C)
            {
                enemy.enemyDamage *= 0.90f;
            }
            level2 = false;
            level3 = true;
        }
        else if (armorLevel == 3 && level3 == true)
        {
            if (enemy.enemyType == Enemy.Type.A)
            {
                enemy.enemyDamage *= 0.85f;
            }
            else if (enemy.enemyType == Enemy.Type.B)
            {
                enemy.enemyDamage *= 0.85f;
            }
            else if (enemy.enemyType == Enemy.Type.C)
            {
                enemy.enemyDamage *= 0.85f;
            }
            level3 = false;
            level4 = true;
        }
        else if (armorLevel == 4 && level4 == true)
        {
            if (enemy.enemyType == Enemy.Type.A)
            {
                enemy.enemyDamage *= 0.80f;
            }
            else if (enemy.enemyType == Enemy.Type.B)
            {
                enemy.enemyDamage *= 0.80f;
            }
            else if (enemy.enemyType == Enemy.Type.C)
            {
                enemy.enemyDamage *= 0.80f;
            }
            level4 = false;
            level5 = true;
        }
        else if (armorLevel == 5 && level5 == true)
        {
            if (enemy.enemyType == Enemy.Type.A)
            {
                enemy.enemyDamage *= 0.75f;
            }
            else if (enemy.enemyType == Enemy.Type.B)
            {
                enemy.enemyDamage *= 0.75f;
            }
            else if (enemy.enemyType == Enemy.Type.C)
            {
                enemy.enemyDamage *= 0.75f;
            }
            level5 = false;
        }
    }
}
