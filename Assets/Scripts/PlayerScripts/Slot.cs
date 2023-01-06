using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int index;
    bool isSelected = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("ItemPickupHitbox").GetComponent<Inventory>();

    }
    private void Update()
    {
        isSelected = true;
        if ((isSelected == true) && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
            if (transform.childCount <= 0)
            {
                inventory.items[index] = 0;
            }
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<ItemDrop>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
