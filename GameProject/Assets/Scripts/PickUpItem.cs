using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour {

    private SwitchTool switchToolsScript;
    private Collider playerCollider;
    private Canvas interactCanvas;
    private Inventory inventory;
    private ItemDatabase database;

	void Start ()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(); ;
        switchToolsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SwitchTool>();
        interactCanvas = GameObject.FindGameObjectWithTag("Interact Canvas").GetComponent<Canvas>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    }
	
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other == playerCollider)
        {
            interactCanvas.GetComponentInChildren<Text>().text = "Press (E) to pick up.";
            interactCanvas.enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other == playerCollider)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                for (int i = 0; i < database.items.Count; i++)
                {
                    if (database.items[i].itemDropped.tag == gameObject.tag)
                    {
                        database.items[i].itemIsInInventory = true;
                        inventory.items.Add(database.items[i]);
                        inventory.items[inventory.items.Count - 1].itemEquipped = false;
                        inventory.items[inventory.items.Count - 1].itemGameObject.SetActive(false);
                        for (int j = 0; j < switchToolsScript.slots.Count; j++)
                        {
                            if (switchToolsScript.slots[j].sprite == switchToolsScript.maskUI && inventory.items[i] != null)
                            {
                                switchToolsScript.slots[j].sprite = database.items[i].itemIcon;
                                break;
                            }
                        }
                        interactCanvas.enabled = false;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            interactCanvas.enabled = false;
        }
    }
}
