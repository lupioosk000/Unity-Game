using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

    public GameObject player;
    public Canvas interactCanvas;
    private Collider playerCollider;

	// Use this for initialization
	void Start ()
    {
        playerCollider = player.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    void OnTriggerEnter(Collider other)
    {
        
        if (other == playerCollider)
        {
            interactCanvas.GetComponentInChildren<Text>().text = "Press (E) to open.";
            interactCanvas.enabled = true;
        } 
    }

    void OnTriggerStay(Collider other)
    {
        if (other == playerCollider)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                
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
