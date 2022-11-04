using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UPgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock
}

[CreateAssetMenu]
public class upgradeManager : ScriptableObject
{
    public UPgradeType upgradeType;
    public string Name;
    public Sprite icon;
}
