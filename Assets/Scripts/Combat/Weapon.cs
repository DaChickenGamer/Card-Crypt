using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string description;
    public int itemID;
    public int damage;
    public double Cooldown;
    public Sprite icon;
}
