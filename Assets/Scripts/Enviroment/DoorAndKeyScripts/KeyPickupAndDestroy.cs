using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupAndDestroy : MonoBehaviour
{
    public AudioSource CollectKey;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Picked Up Key");
            CollectKey.Play(); // Plays key noise when picking up the key
            PlayerVariablesAndItems.keyCount ++; // Adds key to total number of keys
            Destroy (gameObject); // Destroys the key on the ground
        }
    }
}
