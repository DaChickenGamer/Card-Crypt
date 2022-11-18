using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleePlayer : MonoBehaviour
{

    public Rigidbody2D rb;
    public static float walkSpeed = 3f;
    public float speedLimiter = .55f;
    public InputAction playerMove;

    float inputHorizontal;
    float inputVertical;

    Vector2 moveDirection = Vector2.zero;
    //Animations and states
    Animator animator;
    string currentState;

    const string PLAYER_IDLE = "Melee_Idle";
    const string PLAYER_WALK_LEFT_DOWN = "Melee_Down_Left";
    const string PLAYER_WALK_LEFT = "Melee_Left";
    const string PLAYER_WALK_LEFT_UP = "Melee_Up_Left";
    const string PLAYER_WALK_UP = "Melee_Up";
    const string PLAYER_WALK_RIGHT_UP = "Melee_Up_Right";
    const string PLAYER_WALK_RIGHT = "Melee_Right";
    const string PLAYER_WALK_RIGHT_DOWN = "Melee_Down_Right";
    const string PLAYER_WALK_DOWN = "Melee_Down";


    //this is to change the walk speed to the dash speed
    public float activeMoveSpeed;
    public float dashSpeed = 5f;
    //these are self explanitory
    public float dashLength = .3f, dashCooldown = 3.5f;
    //these are use to make it so you cant spam the dash
    public float dashCounter;
    public static float dashCoolCounter;

    


    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = walkSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update() 
    {
        

        activeMoveSpeed = walkSpeed;
        
        // W & S key inputs
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        // A & D key inputs
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                walkSpeed *= dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                walkSpeed/=dashSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {

        // Makes sure the speed you move diagonally is controlled
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * activeMoveSpeed, inputVertical * activeMoveSpeed);


            if (inputHorizontal > 0 && inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT_UP);
            }
            else if (inputHorizontal < 0 && inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT_UP);
            }
            else if (inputHorizontal > 0 && inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT_DOWN);
            }
            else if (inputHorizontal < 0 && inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT_DOWN);
            }
            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
            else if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
        //animation state changer
        void ChangeAnimationState(string newState)
        {
            //Stop animation from interrupting itself
            if (currentState == newState) return;

            //play new animation
            animator.Play(newState);



            //Update current state
            currentState = newState;
        }
    }
}