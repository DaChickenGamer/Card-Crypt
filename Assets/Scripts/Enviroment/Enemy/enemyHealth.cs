using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int Health = 100;
    public int enemyDamage = 1;
    public GameObject XP;
    public Transform spawnLocation;
    public Quaternion spawnRotation;
    private bool startingAttack;

    public void TakeDamage (int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Debug.Log("Enemy Killed");
            Die();
    }
    }
    public void Die()
    {
        Destroy(this.transform.parent.gameObject); // Gets rid of the parent enemy
    }
    public void OnTriggerStay2D(Collider2D collider)
    {
    if (collider.gameObject.tag == "Player")
        {
            if(!startingAttack) // Checks to see if the enemy is starting an 
            StartCoroutine(DelayedDoDamage()); // Delays when the damage is taken
        }
    }
    private IEnumerator DelayedDoDamage()
    {
        startingAttack = true;
        yield return new WaitForSeconds(.1f); // How long the delay is
        startingAttack = false;
        GameManager.gameManager.healthAmount.Dmg(enemyDamage); // Triggers the enemy damage
    }
}