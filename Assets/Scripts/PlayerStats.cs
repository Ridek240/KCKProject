using UnityEngine;

public class PlayerStats : CharacterStats
{
    public BarSystem barSystem;
    public float MaxStamina = 200;
    public float currentStamina;
    
    protected void Awake()
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

    public bool TryUseStamina(float useStamina)
    {
        if (currentStamina >= useStamina)
        {
            currentStamina -= useStamina;
            return true;
        }
        else return false;
        
    }
    public float GetCurrentStamina()
    {
        return currentStamina;
    }
    public float GetMaxStamina()
    {
        return MaxStamina;
    }
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
