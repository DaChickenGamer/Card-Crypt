using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            PlayerVariablesAndItems.CoinCount+=10;
            Destroy(gameObject);
        }
    }
}
