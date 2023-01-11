using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyHealth : MonoBehaviour
{
    public int Health = 100;
    public int enemyDamage = 1;
    private bool startingAttack;

    public GameObject XP;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    public void TakeDamage (int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Debug.Log("enemy killed");
            Instantiate(XP, spawnLocation.position, spawnRotation);
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
            
            if (!startingAttack)
            StartCoroutine(DelayedDoDamage());
        }
    }

    private IEnumerator DelayedDoDamage()
    {
        startingAttack = true;
        yield return new WaitForSeconds(3f);
        startingAttack = false;
        GameManager.gameManager._playerHealth.Dmg(enemyDamage);
    }
}