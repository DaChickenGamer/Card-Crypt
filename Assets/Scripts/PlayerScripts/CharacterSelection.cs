using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public int melee;
    public static int meleePlayer;
    public int ranged;
    public static int rangedPlayer; 
    public int magic;
    public static int magicPlayer;
    public void start()
    {
        melee = 0;
        ranged = 0;
        magic = 0;
        meleePlayer = 0;
        rangedPlayer = 0;
        magicPlayer = 0;
    }

    public void Update()
    {
        meleePlayer = melee;
        rangedPlayer = ranged;
        magicPlayer = magic;
    }
}
