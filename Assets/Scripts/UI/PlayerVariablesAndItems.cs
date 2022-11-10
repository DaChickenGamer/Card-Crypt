using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerVariablesAndItems : MonoBehaviour
{
    
    public static int keyCount, CoinCount;
    public Text Coins;
    public Text Keys;
    void Update()
    {
        Coins.text = CoinCount.ToString();
        Keys.text = keyCount.ToString();
    }
}
