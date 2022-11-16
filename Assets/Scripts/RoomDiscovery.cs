using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDiscovery : MonoBehaviour
{
    [SerializeField] public float transparancyUndiscover = .8f;
    [SerializeField] public float transparancyDiscover = .5f;
    

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, transparancyUndiscover);        //The player won't be able to see rooms they have not discovered yet
    }


    void OnTriggerEnter2D(Collider2D collider)     //if an object with the tag "player" enters the trigger, the player can see the room they are in
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Entered room");
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);      
        }

    }


    void OnTriggerExit2D(Collider2D collider)     //if an object with the tag "player" exits the trigger, will make the discovered room slightly visible 
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Exited room");
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, transparancyDiscover);
        }
    }
}
