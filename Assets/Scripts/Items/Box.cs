using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioSource Sliding;
    private float speed = 1; // Speed of the box
    private float checkRadius = 912389;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 dir;

    private bool checkforplayer;
    private bool isInpushingrange; // Checks if the player is in pushing range
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        checkforplayer = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInpushingrange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        dir = target.position - transform.position;
        dir.Normalize();
        movement = dir;
    }
    private void FixedUpdate()
    {
        if (checkforplayer && !isInpushingrange) // Checks to see if the player can push the box
        {
            MoveCharacter(movement);
        }
        if (isInpushingrange)
        {
            Debug.Log("Touching box");
            rb.velocity = Vector2.zero;
        }
    }
    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime)); 
    }
    private void OnCollisionEnter2D(Collision2D collision) // Only moves the box when player is pushing
    {
        if (collision.gameObject.tag == "Player")
        {
            Sliding.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Sliding.Stop();
        }
    }

}
