using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectileDamage : MonoBehaviour
{
    public static float basedamage = 1;
    public static int damage;
    
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        enemyHealth enemy = hitInfo.GetComponent<enemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
