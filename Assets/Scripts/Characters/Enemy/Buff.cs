using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : CharacterStats
{

    public CharacterStats Stats;
    public Buff(CharacterStats characterStats)
    {
        Stats = characterStats;
    }

    public override void Die()
    {
        Stats.Die();
    }
    
    public int GetCurrentHealth()
    {
        return Stats.GetCurrentHealth();
    }

    public override void TakeDamage(int damage)
    {
        Stats.TakeDamage(damage);
    }
    public override void TakeHeal(int heal)
    {
        Stats.TakeHeal(heal);
    }
    public override void SetMaxHealth(int health)
    {
        Stats.SetMaxHealth(health);
    }
    public int GetMaxHealth()
    {
        return Stats.GetMaxHealth();
    }
}
