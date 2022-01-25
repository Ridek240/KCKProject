using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBuff : Buff
{
    public MovementBuff(CharacterStats characterStats):base(characterStats)
    {
        base.SetSprintSpeed(10f);
    }

    public override void UpdateStamina()
    {
        base.UpdateStamina();
        base.TakeDamage((int)(150* Time.deltaTime));
    }


}
