using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public string tagTarget = "Player";     

    public List<Collider2D> detectedObjs = new List<Collider2D> ();

    void OnTriggerEnter2D(Collider2D collider)     // If an object with the tag "player" enter the collider, it adds collider to list
    {
        if(collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Add (collider);
        }
    }

    void OnTriggerExit2D(Collider2D collider)  //If an object with the tag "player" exits the collider, it removes collider from list
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
        }
    }
}
