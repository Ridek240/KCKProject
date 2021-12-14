using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GUIManager GUIManager;
    private PlayerControl Player;
    public Inventory inventoryPlayer;
    public List<InvStack> inventory = new List<InvStack>();
    public int InventorySize = 7;
    public List<InventoryItem> inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        Player = GUIManager.Player;
        for (int i = 0; i < InventorySize; i++)
        {
            inventoryItems.Add(GameObject.Find("Items/" + (i + 1).ToString()).GetComponent(typeof(InventoryItem)) as InventoryItem);
            inventoryItems[i].slotNumber = i;
            inventoryItems[i].InventoryMenu = this;
        }
        inventoryPlayer = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        //inventory = Player.GetInventory();
        inventory = inventoryPlayer.items;
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
            if (i < inventory.Count)
                inventoryItems[i].SetItem(inventory[i]);
            else
                inventoryItems[i].SetItem(null);
        }
    }
    public void ThrowItem(int index)
    {
        Player.ThrowItem(index);
    }
}
