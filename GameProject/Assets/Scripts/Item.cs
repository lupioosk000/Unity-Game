using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {

    public string itemName;
    public int itemID;
    public string itemDescription;
    public Sprite itemIcon;
    public bool itemEquipped;
    public bool itemIsInInventory;
    public GameObject itemGameObject;
    public GameObject itemDropped;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Light
    }
}
