using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    private Light flashlight;
    private ItemDatabase database;
    
    void Awake ()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
	}
	
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
	}
}
