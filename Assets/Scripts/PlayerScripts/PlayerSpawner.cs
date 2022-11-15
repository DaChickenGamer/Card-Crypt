using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject melee;
    public GameObject ranged;
    public GameObject magic;
    public Transform spawnLocation;
    public Quaternion spawnRotation;
    public void Melee() 
    { 
        Instantiate(melee, spawnLocation.position, spawnRotation);
        Destroy(spawner);
    }
    public void Ranged()
    {
        Instantiate(ranged, spawnLocation.position, spawnRotation);
        Destroy(spawner);
    }
    public void Magic()
    {
        Instantiate(magic, spawnLocation.position, spawnRotation);
        Destroy(spawner);
    }
}
