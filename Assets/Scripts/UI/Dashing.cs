using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashing : MonoBehaviour
{
    Animator animator;
    const string DASH_READY = "Dash_Ready";
    const string DASH_WAITING = "Dash_Waiting";
    string currentState;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (MeleePlayer.dashCoolCounter > 0||MagicPlayer.dashCoolCounter>0||RangedPlayer.dashCoolCounter>0)
        {
            ChangeAnimationState(DASH_WAITING);
        }
        else if (MeleePlayer.dashCoolCounter <= 0 || MagicPlayer.dashCoolCounter <= 0 || RangedPlayer.dashCoolCounter <= 0)
        {
            ChangeAnimationState(DASH_READY);
        }

    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        //play new animation
        animator.Play(newState);



        //Update current state
        currentState = newState;
    }
}