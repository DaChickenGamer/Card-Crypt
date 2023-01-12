using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponScript : MonoBehaviour
{
    int totalWeapons = 1; // Starting amount of weapons
    public int currentWeaponIndex;

    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentGun;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount; // Finds how many weapons there are
        weapons = new GameObject[totalWeapons]; // Makes a arrary out of the weapons.

        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject; // Checks the Weapon Holder childern for weapons
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentGun = weapons[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.E))
    {
        // Next Weapon
        if (currentWeaponIndex < totalWeapons-1)
        {
            Debug.Log("Changed Weapon");
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            weapons[currentWeaponIndex].SetActive(true);
        }
    }
    if (Input.GetKeyDown(KeyCode.Q))
    {
        // Previous Wewapon
        if (currentWeaponIndex > 0)
        {
            Debug.Log("Changed Weapon");
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            weapons[currentWeaponIndex].SetActive(true);
        }
    }
    }
}
