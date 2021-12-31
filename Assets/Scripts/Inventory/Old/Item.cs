using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Old
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Old/Inventory/Item")]
    public class Item : ScriptableObject
    {
        new public string name = "new Item";
        public string desc = "opis";
        public int stacksize = 3;

        public Item() { }
        public Item(string name, string desc)
        {
            this.name = name;
            this.desc = desc;
        }
    }
}

