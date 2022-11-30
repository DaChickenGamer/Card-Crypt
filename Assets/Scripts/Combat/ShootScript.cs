using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public Transform Weapon;

    Vector2 direction;

    public GameObject Projectile;

    public float ProjectileSpeed;

    public Transform ShootPoint;

    public float fireRate;
    float ReadyForNextShot;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Weapon.position;
        FaceMouse();

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(Time.time > ReadyForNextShot)
            {
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
        GameObject ProjectileIns = Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
        ProjectileIns.GetComponent<Rigidbody2D>().AddForce(ProjectileIns.transform.up * ProjectileSpeed);
        Destroy(ProjectileIns, 3);
    }
}
