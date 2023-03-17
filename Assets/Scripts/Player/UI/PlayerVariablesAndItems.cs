using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerVariablesAndItems : MonoBehaviour
{
    public GameObject level;
    public Transform spawnLocation;
    public Quaternion spawnRotation;
    public static int ID = 1;

    public static int keyCount = 0, CoinCount = 0;
    public static float healthValue = Health._currentHealth;
    public Text Coins;
    public Text Keys;
    public Text Damage;
    void Update()
    {
        Coins.text = CoinCount.ToString(); // Displays the amount of coins
        Keys.text = keyCount.ToString(); // Displays the amount of keys
    }
}
