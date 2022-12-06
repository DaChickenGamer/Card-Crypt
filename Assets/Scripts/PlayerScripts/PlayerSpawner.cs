using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public static  int PlayerVarible=0;
    public GameObject spawner;
    public GameObject melee;
    public GameObject ranged;
    public GameObject magic;
    public Transform spawnLocation;
    public Quaternion spawnRotation;
    public void Melee() 
    {
        PlayerVarible += 1;
    }
    public void Ranged()
    {
        PlayerVarible += 2;
    }
    public void Magic()
    {
        PlayerVarible+= 3;
    }
    public void FixedUpdate()
    {
        if(PlayerVarible == 1)
        {
            Instantiate(melee, spawnLocation.position, spawnRotation); 
            Destroy(spawner);
        }
        else if(PlayerVarible == 2)
        {
            Instantiate(ranged, spawnLocation.position, spawnRotation);
            Destroy(spawner);
        }
        else if (PlayerVarible == 3)
        {
            Instantiate(magic, spawnLocation.position, spawnRotation);
            Destroy(spawner);
        }
    }
}
