using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public List<Item> items = new List<Item>();
    private Inventory() { }
    public static Inventory GetInstance() { return instance; }

    void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("instance error");
            return;
        }
        instance = this;
    }
   
    public bool Add(Item item)
    {
        bool cross = true;
  
        foreach (Item it in items)
        {
            if (it.ItemType == item.ItemType && it.GetActualStackSize() < item.GetMaxStackSize())
            {
                it.SetActualStackSize(it.GetActualStackSize() + 1);
                cross = false;
                break;
            }
        }

        if (cross)
        {
            items.Add(item);
        }

        Debug.Log("ItemAdded" + item.GetName());

        return true;
    }


    public void Remove(int id)
    {
        Item invStack = items[id];
        if (invStack.GetActualStackSize() > 2)
        {
            invStack.SetActualStackSize(invStack.GetActualStackSize() - 1);
        }
        else
        {
            items.RemoveAt(id);
        }


    }
    public Item AddItem(ItemType itemType)
    {
        return new Item(itemType);
    }

    private void Start()
    {
        ItemType item = ItemMenager.GetItemType("Sword");
        if (item != null)
            Add(new Item(item));
        item = ItemMenager.GetItemType("Metal");
        if (item != null)
            Add(new Item(item));
    }
}
