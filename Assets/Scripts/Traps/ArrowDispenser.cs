using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{
    //Select the "projectile" object to spawn
    public GameObject projectile;

    //Location to spawn "projectile"
    public Transform spawnLocation;

    //Rotaion of "projectile"
    public Quaternion spawnRotation;

    public PlayerDetection detectionZone;

    public float spawnTime = 0.5f;

    //Track time since last "projectile" spawn
    private float timeSinceSpawned = 0.5f;


    //How many Arrows are spawned
    void Update()
    {
        if (detectionZone.detectedObjs.Count > 0)   //if the list count in player detection is greater then 0
        {
            timeSinceSpawned += Time.deltaTime;

            if (timeSinceSpawned >= spawnTime)      //Then it spawns the arrows
            {
                Instantiate(projectile, spawnLocation.position, spawnRotation);     //Spawns the selected projectile in selected position and rotation
                timeSinceSpawned = 0;   //resets timer
            }
        }

        else
        { 
            timeSinceSpawned = 0.5f;   //resets timer
        }
    }

}
