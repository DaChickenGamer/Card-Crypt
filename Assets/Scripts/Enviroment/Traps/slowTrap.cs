using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowTrap : MonoBehaviour
{
    [SerializeField] private float movementReduction = 2.0f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && ((MeleePlayer.walkSpeed > 2 && MeleePlayer.walkSpeed < 5) || (RangedPlayer.walkSpeed > 2 && RangedPlayer.walkSpeed < 5) || (MagicPlayer.walkSpeed > 2 && MagicPlayer.walkSpeed < 5 )))  //collision detectores for activating trap and activating damage
        {
            MeleePlayer.walkSpeed -= movementReduction;
            RangedPlayer.walkSpeed -= movementReduction;
            MagicPlayer.walkSpeed -= movementReduction;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && (MeleePlayer.walkSpeed < 20 || RangedPlayer.walkSpeed < 20 || MagicPlayer.walkSpeed < 20))   //collision detectores for activating trap and activating damage
        {
            Debug.Log("you are slowed down");
            MeleePlayer.walkSpeed = 4;
            RangedPlayer.walkSpeed = 4;
            MagicPlayer.walkSpeed = 4;
        }
    }
}
