using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float currentEnemyHealth = 10;


    // amount is the amount of damage you want to apply

    public void ApplyDamage(int amount)
    {
        currentEnemyHealth -= amount;
        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
