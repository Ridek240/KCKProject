using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;
    public PlayerStats playerstats;
    public MouseLook mouseLook;

    public ItemMenager itemMenager;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public Inventory inventory;
    public UIStatus currentStatus;
    public int inventoryCursor = 0;

    private Vector3 velocity;
    public float gravity = -9.81f;
    public Vector3 input;
    public Vector3 move;

    private static PlayerControl _instance;
    public static PlayerControl Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        currentStatus = UIStatus.InGame;
        playerstats = gameObject.GetComponent(typeof(PlayerStats)) as PlayerStats;
        itemMenager = new ItemMenager();
        inventory = Inventory.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook.currentStatus = currentStatus;
        ItemType item = ItemMenager.GetItemType("Sword");
        if (currentStatus == UIStatus.InventoryMenu)
            InventoryMovement();
    }

    void FixedUpdate()
    {
        if (currentStatus == UIStatus.InGame)
            GetInput();
        else
            input = Vector3.zero;
        Movement();
    }
    void GetInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        input.y = Input.GetButtonDown("Jump") ? 1 : 0;
    }
    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (input.y == 1 && isGrounded && playerstats.TryUseStamina(20))
        {
            velocity.y = Mathf.Sqrt(playerstats.jumpHeight * 2f * -gravity);
        }
        move = transform.right * input.x + transform.forward * input.z;
        velocity.y += gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift) && move != Vector3.zero && playerstats.TryUseStamina(2))
        {
            move *= playerstats.sprintspeed / playerstats.speed;
        }
        move *= playerstats.speed;

        characterController.Move((velocity + move) * Time.deltaTime);
    }

    void InventoryMovement()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            if (GetInventory().Count != 0)
            {
                int y = (int)Mathf.Sign(Input.GetAxis("Vertical"));
                inventoryCursor += GetInventory().Count - y;
                inventoryCursor = inventoryCursor % GetInventory().Count;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Q)) 
        {
            ThrowItem();
        }
    }

    public List<Item> GetInventory() { return inventory.items; }
    public bool IsInventoryOpen() { return currentStatus == UIStatus.InventoryMenu; }
    public int GetInventoryCursor() { return inventoryCursor; }
    public int GetHealth() { return playerstats.GetCurrentHealth(); }
    public int GetMaxHealth() { return playerstats.GetMaxHealth(); }
    public float GetStamina() { return playerstats.GetCurrentStamina(); }
    public float GetMaxStamina() { return playerstats.GetMaxStamina(); }
    public void ThrowItem() { inventory.Remove(inventoryCursor); }
    public void ThrowItem(int index) { inventory.Remove(index); }
}
