using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerStats playerstats;
    public CharacterController characterController;
    public float speed = 12f;
    public float sprintspeed = 30f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    // Update is called once per frame
    public Vector3 move;
    void Start()
    {
        playerstats = gameObject.GetComponent(typeof(PlayerStats)) as PlayerStats;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded&&velocity.y<0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump")&&isGrounded&& playerstats.TryUseStamina(20))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * -gravity);
        }
         move = transform.right * x + transform.forward * z;


        if(Input.GetKey(KeyCode.O))
        {
            Debug.Log("System Debug Pause");
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && move!=Vector3.zero && playerstats.TryUseStamina(2) )
        {
            characterController.Move(move * sprintspeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * speed * Time.deltaTime);
        }
    }


}
