using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{
    public GameObject projectile; //Select the "projectile" object to spawn

    public Transform spawnLocation; //Location to spawn "projectile"

    public Quaternion spawnRotation; // Rotaion of "projectile"

    public PlayerDetection detectionZone;

    public float spawnTime = 0.5f;

    //Track time since last "projectile" spawn
    private float timeSinceSpawned = 0.5f;

    void Update()
    {
        if (detectionZone.detectedObjs.Count > 0)  //If the list count in player detection is greater then 0
        {
            timeSinceSpawned += Time.deltaTime;

            if (timeSinceSpawned >= spawnTime) // Spawns the arrows
            {
                Debug.Log("Arrow Shot");
                Instantiate(projectile, spawnLocation.position, spawnRotation);  //Spawns the selected projectile in selected position and rotation
                timeSinceSpawned = 0;   // Resets timer
            }
        }

        else
        { 
            timeSinceSpawned = 0.5f;   // Resets timer
        }
    }

}
