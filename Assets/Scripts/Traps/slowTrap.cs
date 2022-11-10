using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowTrap : MonoBehaviour
{
    [SerializeField] private float movementReduction = 2.0f;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player" && playerMovement.walkSpeed > 2 && playerMovement.walkSpeed < 10)   //collision detectores for activating trap and activating damage
        {
            playerMovement.walkSpeed /= movementReduction;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player" && playerMovement.walkSpeed < 20)   //collision detectores for activating trap and activating damage
        {
            playerMovement.walkSpeed *= movementReduction;
        }
    }
}
