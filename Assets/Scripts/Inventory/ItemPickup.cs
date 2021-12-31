using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public ItemType item;
    public override void Interact()
    {
        Pickup();
    }

    void Pickup()
    {
        
        Debug.Log("Picking up "+ item.Name);
        if (Inventory.instance.Add(new Item(item)));
        {
            Destroy(gameObject); 
        }
    }
    
}
