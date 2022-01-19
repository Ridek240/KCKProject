using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenager
{
    static List<ItemType> itemTypes = new List<ItemType>();

    static ItemMenager()
    {
        Object[] items = Resources.LoadAll("Items", typeof(ItemType));
        foreach (var item in items)
        {
            itemTypes.Add(item as ItemType);
        }
    }

    public static ItemType GetItemType(string itemTypeName)
    {
        foreach (var item in itemTypes)
        {
            int alpha = item.name.CompareTo(itemTypeName);
            
            if (item.name.CompareTo(itemTypeName) == 0)
                return item;
        }
        return null;
    }
}
