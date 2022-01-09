using UnityEngine;

public class PlayerStats : CharacterStats
{
    public PlayerStats() : base()
    {
        currentStamina = MaxStamina;
    }
    /*
    protected new void Awake()
    {
        base.Awake();
        currentStamina = MaxStamina;
        barSystem.SetMaxStats(MaxHealth, MaxStamina);
    }

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeHeal(20);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(-20);
        }
    }

    void FixedUpdate()
    {
        currentStamina += 0.5f;
        currentStamina = Mathf.Clamp(currentStamina, 0f, MaxStamina);
        barSystem.SetStamina(currentStamina);
    }
    //*/
    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        barSystem.SetHealth(currentHealth);
    }
    public override void TakeHeal(int heal)
    {
        base.TakeHeal(heal);
        barSystem.SetHealth(currentHealth);
    }

}
