using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed = 3f;   //The speed of the enemy
    private Transform target;  //Targets the player when in the area
    private Transform target2; //Stops targeting if the enemy is touching the player


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player targeted");
            target = other.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player no longer targeted");
            target = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Touching player");
            target2 = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player found but not touching");
            target2 = null;
        }
    }

    private void Update()
    {
        if (target2 != null)
        {
            float step = 0;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step); 
        }
        else if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }


    }

}
