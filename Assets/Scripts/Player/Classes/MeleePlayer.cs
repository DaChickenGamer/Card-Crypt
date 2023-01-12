using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeleePlayer : MonoBehaviour
{
    Rigidbody2D rb;

    public static float walkSpeed = 4f;
    public float speedLimiter = .55f;
    float inputHorizontal;
    float inputVertical;

    //Animations and states
    Animator animator;
    string currentState;

    const string PLAYER_IDLE = "Melee_Idle_With_Hands";
    const string PLAYER_WALK_LEFT_DOWN = "Melee_Down_Left_With_Hands";
    const string PLAYER_WALK_LEFT = "Melee_Left_With_Hands";
    const string PLAYER_WALK_LEFT_UP = "Melee_Up_Left_With_Hands";
    const string PLAYER_WALK_UP = "Melee_Up_With_Hands";
    const string PLAYER_WALK_RIGHT_UP = "Melee_Up_Right_With_Hands";
    const string PLAYER_WALK_RIGHT = "Melee_Right_With_Hands";
    const string PLAYER_WALK_RIGHT_DOWN = "Melee_Down_Righ_With_Hands";
    const string PLAYER_WALK_DOWN = "Melee_Down_With_Hands";


    // This is to change the walk speed to the dash speed
    public float activeMoveSpeed;
    public float dashSpeed = 5f;
    public float dashLength = .3f, dashCooldown = 3.5f;
    // These are used to make it so you cant spam the dash
    public float dashCounter;
    public static float dashCoolCounter;

    void Start()
    {
        Debug.Log("Melee Player Selected");
        activeMoveSpeed = walkSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void Update() 
    {
        activeMoveSpeed = walkSpeed;
        
        // W & S key inputs
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        // A & D key inputs
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0) // Checks if the cooldown is over
            {
                walkSpeed *= dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0) // Lessens the cooldown timer
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                walkSpeed /= dashSpeed;
                dashCoolCounter = dashCooldown;
                if (walkSpeed != 4)
                    walkSpeed = 4; // Makes it so you can't go over 4 speed
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            if (dashCoolCounter == 0)
                Debug.Log("Dash Ready");
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

            // Changes the animations based on the direction the character is facing
            if (inputHorizontal > 0 && inputVertical > 0)
            ChangeAnimationState(PLAYER_WALK_RIGHT_UP);
            else if (inputHorizontal < 0 && inputVertical > 0)
            ChangeAnimationState(PLAYER_WALK_LEFT_UP);
            else if (inputHorizontal > 0 && inputVertical < 0)
            ChangeAnimationState(PLAYER_WALK_RIGHT_DOWN);
            else if (inputHorizontal < 0 && inputVertical < 0)
            ChangeAnimationState(PLAYER_WALK_LEFT_DOWN);
            else if (inputHorizontal < 0)
            ChangeAnimationState(PLAYER_WALK_LEFT);
            else if (inputVertical > 0)
            ChangeAnimationState(PLAYER_WALK_UP);
            else if (inputVertical < 0)
            ChangeAnimationState(PLAYER_WALK_DOWN);
            else if (inputHorizontal > 0)
            ChangeAnimationState(PLAYER_WALK_RIGHT);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
        //Animation state changer
        void ChangeAnimationState(string newState)
        {
            //Stop animation from interrupting itself
            if (currentState == newState) return;

            // Plays new animation
            animator.Play(newState);



            //Update current state
            currentState = newState;
        }
    }
}