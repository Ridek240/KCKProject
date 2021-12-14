using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
   
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


    public List<InvStack> items = new List<InvStack>();
    public bool Add(Item item)
    {
        bool cross = true;
        //Item checkstacks = null;
        foreach (InvStack it in items)
        {
            if (it.item == item && it.actualstack < item.stacksize)
            {
                it.actualstack++;
                cross = false;
            }
        }
        //checkstacks = items.Find(checkstacks.item == item, checkstacksactualstack < item.stacksize);
        //if(checkstacks!=null)
        if (cross)
        {
            items.Add(new InvStack(item));
        }

        Debug.Log("ItemAdded" + item.name);
        if (onItemChanged != null)
        { onItemChanged.Invoke(); }
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
        InvStack invStack = items[id];
        if (invStack.actualstack > 2)
        {
            invStack.actualstack -= 1;
        }
        else
        {
            items.RemoveAt(id);
        }
        

        if (onItemChanged != null)
        { onItemChanged.Invoke(); }
    }
    private void Start()
    {
        Add(new Item("Sword", "Good one"));
        Add(new Item("Metal", "Heavy"));
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