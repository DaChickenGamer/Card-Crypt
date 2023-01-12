using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;
    GameObject ItemPickupHitbox;
    bool canPickup = false;

    private void Update()
    {
        ItemPickupHitbox = GameObject.FindGameObjectWithTag("ItemPickupHitbox");
        if (inventory == null) // Checks if the inventory is in the game
        {
            inventory = GameObject.FindGameObjectWithTag("ItemPickupHitbox").GetComponent<Inventory>();
            Debug.Log("Inventory Working");
        }
        if (canPickup == true) // Checks to see if an item can be picked up
            ItemPickup();
    }

    private void OnTriggerEnter2D(Collider2D other) // If the player goes over the object it can be picked up
    {
        canPickup = true;
        Debug.Log("Entered Object");
    }
    private void OnTriggerExit2D(Collider2D other) // When the player leaves the object they can no longer pick it up
    {
        canPickup = false;
        Debug.Log("Exited Object");
    }
    private void ItemPickup()
    {
        if (ItemPickupHitbox && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Picking Up Object");
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0) // Checks if the slot is empty
                {
                    inventory.items[i] = 1; // Makes the slot considered full
                    Instantiate(itemButton, inventory.slots[i].transform.position, inventory.slots[i].transform.rotation, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}