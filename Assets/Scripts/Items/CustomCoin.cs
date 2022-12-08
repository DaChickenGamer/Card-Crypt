using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCoin : MonoBehaviour
{
    public int Value;
    public AudioSource CollectCoin;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CollectCoin.Play();
            PlayerVariablesAndItems.CoinCount += Value;
        }
    }
}
