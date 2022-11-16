using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDamage : MonoBehaviour
{
    public int damage = 1;

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
