using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : Buff
{
    public HealthBuff(CharacterStats characterStats, float amount) : base(characterStats)
    {
        int health = base.GetMaxHealth();
        base.SetMaxHealth((int)(amount * health));
    }
    public HealthBuff(CharacterStats characterStats) : base(characterStats)
    {
        int health = base.GetMaxHealth();
        base.SetMaxHealth((int)(1.5 * health));
        Debug.Log("HELP ME");
    }
}
