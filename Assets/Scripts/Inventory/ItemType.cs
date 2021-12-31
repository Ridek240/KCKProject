using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemType : ScriptableObject
{
    public string Name;
    public string Description;
    public int MaxDurability;
    public int MaxStackSize;
}
