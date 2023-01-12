using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int index;
    bool isSelected = false;
    GameObject hotbar;
    int totalItems = 1;
    public int currentItemIndex;
    public GameObject[] items;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("ItemPickupHitbox").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Debug.Log("You're on index " + currentItemIndex);
        // Drops item from slot when selected
        if ((isSelected == true) && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
            if (transform.childCount <= 0)
            {
                inventory.items[index] = 0;
            }
        }
        // Selects Hot Bar Slot
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentItemIndex = 0;
            Debug.Log("Slot 1 Selected");
            isSelected = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentItemIndex = 1;
            Debug.Log("Slot 2 Selected");
            isSelected = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentItemIndex = 2;
            Debug.Log("Slot 3 Selected");
            isSelected = true;
        }
         if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentItemIndex = 3;
            Debug.Log("Slot 4 Selected");
            isSelected = true;
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            Transform selectedChild = transform.GetChild(currentItemIndex);
            if (isSelected == true)
            {
                selectedChild.GetComponent<ItemDrop>().SpawnDroppedItem();
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
