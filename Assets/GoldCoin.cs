using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            PlayerVariablesAndItems.CoinCount+=20;
            Destroy(gameObject);
        }
    }
}
