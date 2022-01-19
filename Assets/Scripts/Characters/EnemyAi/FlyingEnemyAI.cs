using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : EnemyAI
{

    public int Fly = 0;
    public bool IsTired = false;


    public override void Awake()
    {
        base.Awake();
        characterStats = new StaminaBuff(characterStats);
    }


    public override void EnemyMovement()
    {
        if(IsTired==false)
        {
            StateFlying();
            ActionMove();
        }
        else
        {
            StateTired();
        }




    }

    public void ActionMove()
    {
        if(characterStats.TryUseStamina(50* Time.deltaTime) ==true)
        {
            characterController.Move((velocity + move * characterStats.speed) * Time.deltaTime);
            transform.Rotate(new Vector3(0f, 1f, 0f));
        }
        else { 
            IsTired = true;
            move = new Vector3(0f,0f,0f);
              }
    }

    public void StateFlying()
    {
        if(transform.position.y<20)
        {
            Fly = 1;
        }
        else { Fly = 0; }

        move = transform.forward + transform.up * Fly;
    }

    public void StateTired()
    {
        
        Gravity();
        if(isGrounded==true)
        {
            characterStats.UpdateStamina();
            if (characterStats.GetCurrentStamina() == characterStats.GetMaxStamina())
                IsTired = false;
        }
    }


}
