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
    public GameObject currentWeapon;
    public GameObject[] items;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("ItemPickupHitbox").GetComponent<Inventory>();

        totalItems = hotbar.transform.childCount;
        items = new GameObject[totalItems];

        for (int i = 0; i < totalItems; i++)
        {
            items[i] = hotbar.transform.GetChild(i).gameObject;
            items[i].SetActive(false);
        }

        items[0].SetActive(true);
        currentWeapon = items[0];
        currentItemIndex = 0;

    }
    private void Update()
    {
        if ((isSelected == true) && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
            if (transform.childCount <= 0)
            {
                inventory.items[index] = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentItemIndex = 0;
            Debug.Log("Slot 1 Selected");
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentItemIndex = 1;
            Debug.Log("Slot 2 Selected");
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentItemIndex = 2;
            Debug.Log("Slot 3 Selected");
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
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
            child.GetComponent<ItemDrop>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
