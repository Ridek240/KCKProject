using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBuff : Buff
{
    public StaminaBuff(CharacterStats characterStats) : base (characterStats)
    {
        base.SetMaxStamina((int)(base.GetMaxStamina() * 2.5f));
        base.SetStaminaRegen(2.0f);
    }
}
