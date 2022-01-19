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
    public override int GetCurrentHealth()
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
    public override int GetMaxHealth()
    {
        return Stats.GetMaxHealth();
    }
    public override bool TryUseStamina(float useStamina)
    {
        return Stats.TryUseStamina(useStamina);
    }
    public override float GetCurrentStamina()
    {
        return Stats.GetCurrentStamina();
    }
    public override float GetMaxStamina()
    {
        return Stats.GetMaxStamina();
    }
    public override void UpdateStamina()
    {
        Stats.UpdateStamina();
    }
    public override void UpdateStats()
    {
        Stats.UpdateStats();
    }
    public override void SetMaxStamina(int stamina)
    {
        Stats.SetMaxStamina(stamina);
    }
    public override void SetStaminaRegen(float stamina)
    {
        Stats.SetStaminaRegen(stamina);
    }
}
