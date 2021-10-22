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



    


    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        items.Add(item);
        Debug.Log("ItemAdded"+ item.name);
        return true;
        if(onItemChanged!=null)
        { onItemChanged.Invoke(); }
    }
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChanged != null)
        { onItemChanged.Invoke(); }
    }

}
