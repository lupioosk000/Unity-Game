using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SwitchTool : MonoBehaviour {
    
    private KeyCode[] numberKeys = new KeyCode[10];
    private Inventory inventory;
    private ItemDatabase database;
    public List<Image> slots = new List<Image>(9);
    public Sprite maskUI;
    public Image selectedUI;
    public GameObject dropSpawn;

	// Use this for initialization
	void Start ()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        numberKeys[0] = KeyCode.Alpha1;
        numberKeys[1] = KeyCode.Alpha2;
        numberKeys[2] = KeyCode.Alpha3;
        numberKeys[3] = KeyCode.Alpha4;
        numberKeys[4] = KeyCode.Alpha5;
        numberKeys[5] = KeyCode.Alpha6;
        numberKeys[6] = KeyCode.Alpha7;
        numberKeys[7] = KeyCode.Alpha8;
        numberKeys[8] = KeyCode.Alpha9;
        numberKeys[9] = KeyCode.Alpha0;
        selectedUI.rectTransform.position = slots[0].rectTransform.position;
        for (int i = 0; i < inventory.items.Count; i++)
        {
            for (int j = 0; j < slots.Count; j++)
            {
                if (slots[j].sprite == maskUI && inventory.items[i] != null)
                {
                    slots[j].sprite = inventory.items[i].itemIcon;
                    break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int j = 0; j < slots.Count; j++)
        {
            if (slots[j].rectTransform.position == selectedUI.rectTransform.position)
            {
                for (int i = 0; i < inventory.items.Count; i++)
                {
                    if (slots[j].sprite == inventory.items[i].itemIcon)
                    {
                        inventory.items[i].itemGameObject.SetActive(true);
                    }
                    else
                    {
                        inventory.items[i].itemGameObject.SetActive(false);
                    }
                }
            }
        }
        Switch(0);
        Switch(1);
        Switch(2);
        Switch(3);
        Switch(4);
        Switch(5);
        Switch(6);
        Switch(7);
        Switch(8);
        if (Input.GetKeyUp(KeyCode.Q)) DropItem(); 
    }

    private void Switch (int index)
    {
        if (Input.GetKeyUp(numberKeys[index]))
        {
            selectedUI.rectTransform.position = slots[index].rectTransform.position;
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if (slots[index].sprite == inventory.items[i].itemIcon)
                {
                    inventory.items[i].itemEquipped = true;
                }
                else
                {
                    inventory.items[i].itemEquipped = false;
                }
            }
        }
    }

    private void DropItem ()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].itemGameObject.activeSelf)
            {
                Instantiate(inventory.items[i].itemDropped, dropSpawn.transform.position, inventory.items[i].itemDropped.transform.rotation);
                inventory.items[i].itemGameObject.SetActive(false);
                inventory.items.RemoveAt(i);
                for (int j = i; j < slots.Count - 1; j++)
                {
                    slots[j].sprite = slots[j + 1].sprite;
                }
                slots[slots.Count - 1].sprite = maskUI;
            }
        }
    }
}
