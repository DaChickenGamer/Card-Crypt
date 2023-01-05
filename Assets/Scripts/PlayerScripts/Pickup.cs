using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;

    private void Update()
    {
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            Debug.Log("Inventory Working");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // spawn the sun button at the first available inventory slot ! 
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                { // check whether the slot is EMPTY
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
            }
        }

    }
}
