using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectileDamage : MonoBehaviour
{
        public void OnTriggerEnter2D(Collider2D hitInfo)
        {
            EnemyBehaviour enemy = hitInfo.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.TakeDamage((int)ShootScript.damage);
                StartCoroutine(DelayedDoDestroy());
            }
            else if (hitInfo.gameObject.tag == "Walls")
            {
                StartCoroutine(DelayedDoDestroy());
            }
        }
        private IEnumerator DelayedDoDestroy()
        {
            yield return new WaitForSeconds(.03f);
            Destroy(GameObject.FindWithTag("Projectile"));
        }
  

}
