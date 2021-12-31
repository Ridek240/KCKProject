using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GUIManager GUIManager;
    private PlayerControl Player;
    public Inventory inventory;
    public int InventorySize = 7;
    public List<InventoryItem> inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerControl.Instance;
        inventory = Inventory.instance;
        for (int i = 0; i < InventorySize; i++)
        {
            inventoryItems.Add(GameObject.Find("Items/" + (i + 1).ToString()).GetComponent(typeof(InventoryItem)) as InventoryItem);
            inventoryItems[i].slotNumber = i;
            inventoryItems[i].InventoryMenu = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        draw();
        SetInactiveItem();
        inventoryItems[Player.GetInventoryCursor()].selected = true;
    }
    public void SetInactiveItem()
    {
        foreach (InventoryItem item in inventoryItems)
        {
            item.selected = false;
        }
    }

    void draw()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (i < inventory.items.Count)
                inventoryItems[i].SetItem(inventory.items[i]);
            else
                inventoryItems[i].SetItem(null);
        }
    }
    public void ThrowItem(int index)
    {
        Player.ThrowItem(index);
    }
}
