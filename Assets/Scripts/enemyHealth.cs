using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int Health = 100;
    public int enemyDamage = 1;
    public GameObject Player;

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
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //enemyHealth enemy = hitInfo.GetComponent<enemyHealth>();
        if (Player != null)
        {
            if (GameManager.gameManager._playerHealth.healthAmount <= 0)
            {
            Destroy(Player);
            }
        }
    }
}
