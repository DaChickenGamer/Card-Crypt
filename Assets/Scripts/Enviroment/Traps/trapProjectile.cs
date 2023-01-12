using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapProjectile : MonoBehaviour
{
    public float moveSpeed = 5f; //Speed of the projectile

    public float timeToLive = 5f; //Projectile lifetime

    private float timeSinceSpawned = 0f;

    void Update()
    {
        transform.position += moveSpeed * transform.right * Time.deltaTime; // How fast the projectile should move and where it should move

        timeSinceSpawned += Time.deltaTime; // Increments the time since spawned based on the ingame time

        if (timeSinceSpawned > timeToLive) // Compares how the project has been spawned and how long it has to live
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        string tag = collider.gameObject.tag; 
        if (tag == "Player")
        {
            Debug.Log("Trap Damaging Player");
            GameManager.gameManager._playerHealth.Dmg(20); // Damages The Player
        }
    }
}
