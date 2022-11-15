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
            CollectKey.Play();
            PlayerVariablesAndItems.keyCount ++;
            Destroy (gameObject);
        }
    }
}
