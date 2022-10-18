using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : MonoBehaviour
{
    public AudioSource CollectCoin;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            CollectCoin.Play();
            PlayerVariablesAndItems.CoinCount+=10;
            Destroy(gameObject);
        }
    }
}
