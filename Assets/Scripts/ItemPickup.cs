using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        Pickup();
    }

    void Pickup()
    {
        
        Debug.Log("Picking up "+ item.name);
        if (Inventory.instance.Add(item))
        {
            Destroy(gameObject); 
        }
    }
    
}
