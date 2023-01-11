using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public Transform Weapon; 

    Vector2 direction;

    public GameObject Projectile;

    public float ProjectileSpeed, Damage;

    public Transform ShootPoint;

    public static float damage;

    public float fireRate;
    float ReadyForNextShot;

    void Update()
    {
        damage = Damage;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Weapon.position;//faces mouse
        FaceMouse();

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(Time.time > ReadyForNextShot)
            {
                Debug.Log("you can shoot");
                ReadyForNextShot = Time.time + 1/fireRate;
                Shoot();
            }
        }
    }
    void FaceMouse()
    {
        
        Weapon.transform.up = direction;
    }
    void Shoot()
    {
        Debug.Log("you shot");
        GameObject ProjectileIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        ProjectileIns.GetComponent<Rigidbody2D>().AddForce(ProjectileIns.transform.up * ProjectileSpeed);
        Destroy(ProjectileIns, 3);
    }
}
