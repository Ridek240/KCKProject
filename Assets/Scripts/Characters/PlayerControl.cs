using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;
    public CharacterStats playerstats;
    public MouseLook mouseLook;

    public ItemMenager itemMenager;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public Inventory inventory;
    public UIStatus currentStatus;
    public int inventoryCursor = 0;

    private Vector3 velocity;
    public float gravity = -9.81f;
    public Vector3 input;
    public Vector3 move;

    private static PlayerControl _instance;
    public static PlayerControl GetInstance() { return _instance; }

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
        playerstats = new PlayerStats();
        Debug.Log(playerstats.GetMaxHealth().ToString());
        playerstats = new HealthBuff(playerstats);
        playerstats = new HealthBuff(playerstats);
        playerstats = new MovementBuff(playerstats);
        playerstats = new StaminaBuff(playerstats);
        Debug.Log(playerstats.GetMaxHealth().ToString());
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
        playerstats.UpdateStats();
        bool usingStamina = false;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (input.y == 1 && isGrounded && playerstats.TryUseStamina(20))
        {
            velocity.y = Mathf.Sqrt(playerstats.jumpHeight * 2f * -gravity);
            usingStamina = true;
        }

        move = transform.right * input.x + transform.forward * input.z;
        velocity.y += gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift) && move != Vector3.zero && playerstats.TryUseStamina(100 * Time.deltaTime))
        {
            move *= playerstats.sprintspeed / playerstats.speed;
            usingStamina = true;
        }
        move *= playerstats.speed;

        characterController.Move((velocity + move) * Time.deltaTime);

        if (!usingStamina)
        {
            playerstats.UpdateStamina();
        }
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
    public void ThrowItem() { inventory.Remove(inventoryCursor); }
    public void ThrowItem(int index) { inventory.Remove(index); }
}
