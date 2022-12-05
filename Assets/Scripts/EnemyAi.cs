using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float rotationSpeed;
    public float speed = 3f;
    private Transform target;
    private Rigidbody2D rb;
    private Transform target2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            target2 = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
