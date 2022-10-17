using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopperCoin : MonoBehaviour
{
    public AudioSource CollectCoin;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            CollectCoin.Play();
            PlayerVariablesAndItems.CoinCount+=5;
            Destroy(gameObject);
        }
    }
}
