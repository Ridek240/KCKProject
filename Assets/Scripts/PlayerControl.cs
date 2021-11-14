using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;
    public PlayerStats playerstats;

    public int CurrentHealth = 3;
    public int MaxHealth = 35;
    public int CurrentStamina = 14;
    public int MaxStamina = 36;

    public float speed = 12f;
    public float sprintspeed = 30f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public bool inInventory = false;
    public Inventory inventory;
    public int inventoryCursor = 0;

    public Vector3 move;

    void Start()
    {
        playerstats = gameObject.GetComponent(typeof(PlayerStats)) as PlayerStats;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("InventoryOpen"))
            inInventory = !inInventory;

        if (IsInventoryOpen())
        {
            move = Vector3.zero;
            InventoryMovement();
        }
        else
        {
            Movement();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && move != Vector3.zero && playerstats.TryUseStamina(2))
        {
            characterController.Move(move * sprintspeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * speed * Time.deltaTime);
        }
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded && playerstats.TryUseStamina(20))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * -gravity);
        }
        move = transform.right * x + transform.forward * z;


        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("System Debug Pause");
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void InventoryMovement()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            int y = (int)Mathf.Sign(Input.GetAxis("Vertical"));
            inventoryCursor += GetInventory().Count - y;
            inventoryCursor = inventoryCursor % GetInventory().Count;
        }
        else if (Input.GetKeyDown(KeyCode.Q)) 
        {
            inventory.Remove(inventoryCursor);
        }
    }

    public List<InvStack> GetInventory() { return inventory.items; }
    public bool IsInventoryOpen() { return inInventory; }
    public int GetInventoryCursor() { return inventoryCursor; }
    public int GetHealth() { return playerstats.GetCurrentHealth(); }
    public int GetMaxHealth() { return playerstats.GetMaxHealth(); }
    public float GetStamina() { return playerstats.GetCurrentStamina(); }
    public float GetMaxStamina() { return playerstats.GetMaxStamina(); }
}
