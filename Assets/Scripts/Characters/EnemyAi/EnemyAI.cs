using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    //
    public CharacterStats characterStats;
    public Transform target;
    public CharacterController characterController;

    //movement - checking ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    //movement vectors
    public Vector3 velocity;
    public float gravity = -9.81f;
    public Vector3 input;
    public Vector3 move;

    public virtual void Awake()
    {
        characterController = this.GetComponent(typeof(CharacterController)) as CharacterController;
        //porywanie gracza???
        velocity = new Vector3(0f,0f,0f);
    }

    public void Update()
    {
        EnemyMovement();
        IsGrounded();
    }

    public void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public void Gravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move((velocity + move) * Time.deltaTime);
    }

    public abstract void EnemyMovement();

}
