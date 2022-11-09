using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public static float moveSpeed = 4f;
    public float speedLimiter = .55f;
    public InputAction playerMove;

    Vector2 moveDirection = Vector2.zero;

    //Animations and states
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT_DOWN = "Player_Walk_Left_Down";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_LEFT_UP = "Player_Walk_Left_Up";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_RIGHT_UP = "Player_Walk_Right_Up";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_RIGHT_DOWN = "Player_Walk_Right_Down";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    //this is to change the walk speed to the dash speed
    public float activeMoveSpeed;
    public float dashSpeed = 5f;
    //these are self explanitory
    public float dashLength = .3f, dashCooldown = 3.5f;
    //these are use to make it so you cant spam the dash
    public float dashCounter;
    public static float dashCoolCounter;
    // Start is called before the first frame update

    private void OnEnable()
    {
        playerMove.Enable();
    }
    private void OnDisable()
    {
        playerMove.Disable();
    }
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        activeMoveSpeed = moveSpeed;


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                moveSpeed *= dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                moveSpeed/=dashSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        moveDirection = playerMove.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * activeMoveSpeed, moveDirection.y * activeMoveSpeed);        
    }
}