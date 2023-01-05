using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public static int playerType = 0;
    public GameObject spawner;
    public GameObject melee;
    public GameObject ranged;
    public GameObject magic;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    public void FixedUpdate()
    {
        // It's better to use a switch statement instead of multiple if-else statements
        switch (playerType)
        {
            case 1:
                Instantiate(melee, spawnLocation.position, spawnRotation);
                Destroy(spawner);
                break;
            case 2:
                Instantiate(ranged, spawnLocation.position, spawnRotation);
                Destroy(spawner);
                break;
            case 3:
                Instantiate(magic, spawnLocation.position, spawnRotation);
                Destroy(spawner);
                break;
        }
    }
}