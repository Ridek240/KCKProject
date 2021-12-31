using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public ItemType ItemType;
    public int ActualStackSize;
    public int CurrentDurability;
    public Item(ItemType itemType)
    {
        ItemType = itemType;
        ActualStackSize = 1;
        CurrentDurability = itemType.MaxDurability;
    }

    public string GetName() { return ItemType.Name; }
    public int GetActualStackSize() { return ActualStackSize; }
    public void SetActualStackSize(int value) { ActualStackSize = value; }
    public int GetMaxStackSize() { return ItemType.MaxStackSize; }
}
