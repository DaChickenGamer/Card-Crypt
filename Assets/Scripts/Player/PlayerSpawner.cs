using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public static int playerType = 0;//
    public GameObject spawner;
    public GameObject melee;
    public GameObject ranged;
    public GameObject magic;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    public void FixedUpdate()
    {
        
        switch (playerType)
        {
            case 1:
                Debug.Log("melee selected");
                Instantiate(melee, spawnLocation.position, spawnRotation);
                Destroy(spawner);
                break;
            case 2:
                Debug.Log("ranged selected");
                Instantiate(ranged, spawnLocation.position, spawnRotation);
                Destroy(spawner);
                break;
            case 3:
                Debug.Log("magic ");
                Instantiate(magic, spawnLocation.position, spawnRotation);
                Destroy(spawner);
                break;
        }
    }
}