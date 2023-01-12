using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDroppedItem() // Spawns the item below the player
    {
        Debug.Log("Dropped Item");
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
