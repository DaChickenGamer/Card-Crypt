using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //constant speed of the projectile
    public float moveSpeed = 5f;

    //projectile lifetime
    public float timeToLive = 5f;

    private float timeSinceSpawned = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * transform.right * Time.deltaTime;

        timeSinceSpawned += Time.deltaTime;

        if (timeSinceSpawned > timeToLive)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)     //if an object with the tag "player" enter the collider, it adds collider to list
    {
        string tag = collider.gameObject.tag;
        if (tag == "Player")
        {
            //playerBehavior.PlayerTakeDmg(20);
        }
    }
}
