using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyAI : EnemyAI
{
    public Vector3 Direction;
    public float angle;
    public Vector3 homePosition;


    public override void Awake()
    {
        base.Awake();
        homePosition = transform.position;
    }
    public override void EnemyMovement()
    {
        Gravity();

        if (Vector3.Distance(target.position, transform.position) < 30)
        {
            LookAtPlayer();
            if (Vector3.Distance(target.position, transform.position) < 20)
            {
                WalkForward();
            }
        }
        else
        {
            LookAtHome();
            WalkForward();
        }

    }

    public void LookAtPlayer()
    {
        Direction = target.position - transform.position;
        angle = (Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg);
        transform.localEulerAngles = new Vector3(0f, angle, 0f);
    }
    public void WalkForward()
    {
        move = transform.forward;
        characterController.Move((velocity + move * characterStats.speed) * Time.deltaTime);
    }
    public void LookAtHome()
    {
        Direction = homePosition - transform.position;
        angle = (Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg);
        transform.localEulerAngles = new Vector3(0f, angle, 0f);
    }


}
