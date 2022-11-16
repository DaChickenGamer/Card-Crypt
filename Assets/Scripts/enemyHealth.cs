using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int  Health = 100;

    public void TakeDamage (int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
