using UnityEngine;

public class PlayerStats : CharacterStats
{
    public float MaxStamina = 200;
    public float currentStamina;
    
    protected void Awake()
    {
        base.Awake();
        currentStamina = MaxStamina;
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
    }

    void FixedUpdate()
    {
        currentStamina += 0.5f;
        currentStamina = Mathf.Clamp(currentStamina, 0f, MaxStamina);
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

}
