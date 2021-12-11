using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public PlayerControl Player;
    public List<InvStack> inventory = new List<InvStack>();
    public int InventorySize = 7;
    public List<InventoryItem> inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InventorySize; i++)
        {
            inventoryItems.Add(GameObject.Find("Items/" + (i + 1).ToString()).GetComponent(typeof(InventoryItem)) as InventoryItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        inventory = Player.GetInventory();
        draw();
    }

    void draw()
    {
        for (int i = 0; i < Mathf.Min(inventoryItems.Count, inventory.Count); i++)
        {
            inventoryItems[i].SetItem(inventory[i]);
        }
    }
}
