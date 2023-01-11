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

    public static int keyCount = 0, CoinCount = 0;
    public Text Coins;
    public Text Keys;
    public Text Damage;
    void Update()
    {
        /*xp = (int)exp;
        xpTotal = (int)expTotal;
        if (exp >= expTotal)
        {
            xpAmount += 2;
            exp -= expTotal;
            expTotal *= 1.1f;
            Instantiate(level, spawnLocation.position, spawnRotation);
            Level += 1;
        }*/
        Coins.text = CoinCount.ToString();
        Keys.text = keyCount.ToString();
       // Damage.text = ShootScript.damage.ToString();
    }
}
