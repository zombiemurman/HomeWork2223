using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : IHealth
{
    public HealthComponent(float health)
    {
        Health = health;
        IsDie = false;
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

}
