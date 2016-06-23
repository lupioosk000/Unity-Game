using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    void Update ()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemIsInInventory == false)
            {
                items[i].itemGameObject.SetActive(false);
            }
        }
    }
}
