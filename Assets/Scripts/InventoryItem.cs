using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public InvStack Item;
    public Text ItemCount;
    public Text ItemName;
    public void SetItem(InvStack item)
    {
        Item = item;
        Debug.Log("Dodano");
    }

    public void Update()
    {
        if (Item != null)
        {
            ItemCount.text = Item.actualstack.ToString();
            ItemName.text = Item.item.name.ToString();
        }
        else
        {
            ItemCount.text = "";
            ItemName.text = "";
        }
    }
}
