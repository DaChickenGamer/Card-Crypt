using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    public AudioSource CollectCoin;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            CollectCoin.Play();
            PlayerVariablesAndItems.CoinCount+=20;
            Destroy(gameObject);
        }
    }
}
