using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public InvStack Item;
    public Text ItemCount;
    public Text ItemName;
    public InventoryMenu InventoryMenu;
    public int slotNumber = 0;
    public bool selected = false;
    public GameObject SelectedSprite;
    public void SetItem(InvStack item)
    {
        Item = item;
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
        SelectedSprite.SetActive(selected);
    }

    public void ThrowItem()
    {
        InventoryMenu.ThrowItem(slotNumber);
    }
}
