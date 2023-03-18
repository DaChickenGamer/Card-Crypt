using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    // Fields
    private static float _currentHealth;
    private static float _currentMaxHealth;
    // _ is a naming convention on fields

    // Properties
    public float playerHealthAmount
    {
        // Sets the value for health
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    public float MaxHealth
    {
        // Sets the value for Max health
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }
    public float healthFillAmount
    {
        get
        {
            return _currentHealth / _currentMaxHealth;
        }
        set
        {
            healthFillAmount = value;
        }
    }
    // Constructor
    public Health(float health, float maxHealth)
    {
        // Sets the health and max health in unity
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }
    // Methods
    public void Dmg(float dmgAmount)
    {
        // Damages the player
        if (_currentHealth > 0)
            _currentHealth -= dmgAmount;
    }
    public void Heal(float healAmount)
    {
        Debug.Log("healed");
        // Tells if the character should get healed or not.
        if (_currentHealth < _currentMaxHealth)
            _currentHealth += healAmount;
        if (_currentHealth > _currentMaxHealth)
            _currentMaxHealth = _currentHealth;
    }
}
