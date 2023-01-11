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
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("ItemPickupHitbox").GetComponent<Inventory>();
            Debug.Log("Inventory Working");
        }
        if (canPickup == true)
            ItemPickup();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canPickup = true;
        Debug.Log("Entered Object");
    }
    private void OnTriggerExit2D(Collider2D other)
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
                if (inventory.items[i] == 0)
                { // check whether the slot is EMPTY
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform.position, inventory.slots[i].transform.rotation, inventory.slots[i].transform); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}