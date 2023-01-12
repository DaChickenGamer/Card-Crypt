using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
        public void OnTriggerEnter2D(Collider2D hitInfo)
        {
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
            if (enemy != null) // Checks if there is an enemy
            {
                Debug.Log("Hit Enemy");
                enemy.TakeDamage((int)ShootScript.damage); // If there is an enemy and a projectile it'll damage the enemy
                StartCoroutine(DelayedDoDestroy()); // Delays the damage so you can't spam it
            }
            else if (hitInfo.gameObject.tag == "Walls")
            {
                Debug.Log("Hit wall");
                StartCoroutine(DelayedDoDestroy()); // Makes the projectile get destoryed when it touches a wall but it's delayed
            }
        }
        private IEnumerator DelayedDoDestroy()
        {
            yield return new WaitForSeconds(.03f);
            Destroy(GameObject.FindWithTag("Projectile"));
        }
  

}
