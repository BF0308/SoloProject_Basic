using System;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Consumable,
    Equipment,
    Other
}

public enum ConsumableType
{
    Health,
}

public enum EquipmentType
{
    Helmet,
    Weapon,
    Shield
}
[Serializable]
public class Consumable
{
    public Consumable type;
    public int amount;
}
[Serializable]
public class Equipment
{
    public EquipmentType type;
    public int amount;
}
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;
    public Image Icon;
    
    [Header("Type")]
    public Consumable[] ConsumableType;
    public Equipment[] EquipmentType;
    
}
