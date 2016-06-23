using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private ItemDatabase database;
    public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start ()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();

        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i].itemIsInInventory == true) items.Add(database.items[i]);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
