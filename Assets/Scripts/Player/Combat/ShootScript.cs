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
        damage = Damage; // Converts the two damages
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Converts mouse position to screen position
        direction = mousePos - (Vector2)Weapon.position; //Faces mouse
        FaceMouse();

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(Time.time > ReadyForNextShot)
            {
                Debug.Log("Player can shoot");
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
        Debug.Log("Weapon fired");
        GameObject ProjectileIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation); // Decides where the projectile spawns and how it rotates
        ProjectileIns.GetComponent<Rigidbody2D>().AddForce(ProjectileIns.transform.up * ProjectileSpeed); // Decides how fast the projectile goes
        Destroy(ProjectileIns, 3); // How long till the weapon gets destroyed after it shoots
    }
}
