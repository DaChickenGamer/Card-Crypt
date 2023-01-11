using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehaviour : MonoBehaviour
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
        Destroy(this.transform.parent.gameObject);
    }
    public void OnTriggerStay2D(Collider2D collider)
    {
    if (collider.gameObject.tag == "Player")
        {
            if(!startingAttack)
            StartCoroutine(DelayedDoDamage());
        }
    }
    private IEnumerator DelayedDoDamage()
    {
        startingAttack = true;
        yield return new WaitForSeconds(.1f);
        startingAttack = false;
        GameManager.gameManager._playerHealth.Dmg(enemyDamage);
    }
}