using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : IHealth
{
    private float _maxHealth;

    public HealthComponent(float health)
    {
        Health = health;
        IsDie = false;
        
        _maxHealth = health;
    }

    public float Health { get; private set; }

    public bool IsDie { get; private set; }

    public void TakeDamage(float damage)
    {
        if(damage <= 0)
            return;

        Health -= damage;

        if(Health < 0)
        {
            Health = 0;
            IsDie = true;
        }
            
    }

    public void AddHealth(int amount)
    {
        if (amount <= 0)
            return;

        Health += amount;

        if (Health > _maxHealth)
            Health = _maxHealth;
    }

}
