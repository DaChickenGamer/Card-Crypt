using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource openDoor;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Player") && (PlayerVariablesAndItems.keyCount > 0))
        {
            Debug.Log("Opened door");
            openDoor.Play(); // Plays the audio when opening up the door
            PlayerVariablesAndItems.keyCount--;
            Destroy(gameObject); // Destroys gate on the door
        }
    }
}
