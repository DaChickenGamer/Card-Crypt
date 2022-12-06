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
                Destroy(gameObject);
            }
            else if (hitInfo.gameObject.tag == "Walls")
            {
                Destroy(GameObject.FindWithTag("Projectile"));
            }
        }
  

}
