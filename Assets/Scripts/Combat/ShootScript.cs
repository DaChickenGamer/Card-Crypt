using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public Transform Wand;

    Vector2 direction;

    public GameObject Spell;

    public float SpellSpeed;

    public Transform ShootPoint;

    public float fireRate;
    float ReadyForNextShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Wand.position;
        FaceMouse();

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if(Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1/fireRate;
                shoot();
            }
        }
    }
    void FaceMouse()
    {
        Wand.transform.up = direction;
    }
    void shoot()
    {
        GameObject SpellIns = Instantiate(Spell, ShootPoint.position, ShootPoint.rotation);
        SpellIns.GetComponent<Rigidbody2D>().AddForce(SpellIns.transform.up * SpellSpeed);
        Destroy(SpellIns, 3);
    }
}
