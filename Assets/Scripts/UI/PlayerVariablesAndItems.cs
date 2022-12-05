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

    public static int keyCount=0, CoinCount=0, Level=1, xpTotal, xp, xpAmount=2;
    public static float exp=0, expTotal=10;
    public Text Coins;
    public Text Keys;
    public Text Exp;
    public Text ExpTotal;
    public Text Lvl;
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
        projectileDamage.damage = (int)projectileDamage.basedamage;
        Coins.text = CoinCount.ToString();
        Keys.text = keyCount.ToString();
        Exp.text = xp.ToString();
        ExpTotal.text = xpTotal.ToString();
        Lvl.text = Level.ToString();
        Damage.text = projectileDamage.damage.ToString();
    }
}
