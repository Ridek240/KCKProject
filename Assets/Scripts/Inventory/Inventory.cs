using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    private Inventory() { }
    public static Inventory GetInstance() { return instance; }

    #region Singleton
    void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("instance error");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onItemChanged;
    public bool Add(Item item)
    {
        bool cross = true;
        //Item checkstacks = null;
        foreach (Item it in items)
        {
            if (it.ItemType == item.ItemType && it.GetActualStackSize() < item.GetMaxStackSize())
            {
                it.SetActualStackSize(it.GetActualStackSize() + 1);
                cross = false;
                break;
            }
        }
        //checkstacks = items.Find(checkstacks.item == item, checkstacksactualstack < item.stacksize);
        //if(checkstacks!=null)
        if (cross)
        {
            items.Add(item);
        }

        Debug.Log("ItemAdded" + item.GetName());
        if (onItemChanged != null)
        { 
            onItemChanged.Invoke();
        }
        return true;
    }
    public void Remove(Item item)
    {
        //items.Remove(item);

        if (onItemChanged != null)
        { onItemChanged.Invoke(); }
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

        if (onItemChanged != null)
        { onItemChanged.Invoke(); }
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
public class InvStack
{
    public Item item;
    public int actualstack;
    public InvStack(Item item)
    {
        this.item = item;
        actualstack = 1;
    }
}