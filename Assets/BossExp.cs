using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerVariablesAndItems.exp+=5;
            Destroy(gameObject);
        }
    }
}
