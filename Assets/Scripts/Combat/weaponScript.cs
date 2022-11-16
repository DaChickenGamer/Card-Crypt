using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponScript : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentGun;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentGun = weapons[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.E))
    {
        // Next Wewapon
        if (currentWeaponIndex < totalWeapons-1)
        {
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
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            weapons[currentWeaponIndex].SetActive(true);
        }
    }
    }
}
