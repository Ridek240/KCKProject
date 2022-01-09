using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathBuff : Buff
{
    public OnDeathBuff(CharacterStats characterStats):base(characterStats)
    {

    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if(Stats.Alife==false)
        {
            Die();
        }
    }
    public override void Die()
    {
       // base.Die();
        Debug.Log("dekorator");
        //Destroy(gameObject);
    }
}
