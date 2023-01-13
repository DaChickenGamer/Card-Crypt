using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    void Start()
    {
        healthBar = GetComponent<Image>(); // Gets the health bar image
    }
    void Update()
    {
        try
        {
            healthBar.fillAmount = Health._currentHealth / Health._currentMaxHealth;// Changes the health bar based on the amount of health the player has
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
