using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : EnemyAI
{

    public int inCorrectHeight = 0;
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
            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
        }
        else { 
            IsTired = true;
            move = new Vector3(0f,0f,0f);
            characterStats = new StaminaBuff(characterStats);
              }
    }

    public void StateFlying()
    {
        if(transform.position.y<20)
        {
            inCorrectHeight = 1;
        }
        else { inCorrectHeight = 0; }

        move = transform.forward + transform.up * inCorrectHeight;
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
