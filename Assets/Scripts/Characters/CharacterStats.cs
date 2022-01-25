using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats// : MonoBehaviour
{
    public BarSystem barSystem;
    public int MaxHealth = 100;
    public int currentHealth;

    public float speed = 12f;
    public float jumpHeight = 2f;
    public float MaxStamina = 200;
    public float currentStamina;
    public float staminaRegeneration = 0.5f;

    public float sprintspeed = 30f;


    public virtual void UpdateStamina()
    {
        currentStamina += staminaRegeneration * Time.deltaTime*100f;
        currentStamina = Mathf.Clamp(currentStamina, 0f, MaxStamina);
    }

    public virtual void UpdateStats()
    {
        barSystem = GUIManager.GetInstance().GetBarSystem();
        barSystem.SetMaxStats(MaxHealth, MaxStamina);
        barSystem.SetStamina(currentStamina);
        barSystem.SetHealth(currentHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        
        
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
 
    }

    public virtual void TakeHeal(int heal)
    {
        
        heal = Mathf.Clamp(heal, 0, int.MaxValue);

        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
        
    }
    public virtual bool TryUseStamina(float useStamina)
    {
        if (currentStamina >= useStamina)
        {
            currentStamina -= useStamina;
            return true;
        }
        else return false;

    }
    public virtual float GetCurrentStamina()
    {
        return currentStamina;
    }
    public virtual float GetMaxStamina()
    {
        return MaxStamina;
    }
    public virtual int GetCurrentHealth()
    {
        return currentHealth;
    }
    public virtual int GetMaxHealth()
    {
        return MaxHealth;
    }
    public virtual void SetMaxHealth(int health)
    {
        MaxHealth = health;
    }
    public virtual void SetMaxStamina(int stamina)
    {
        MaxStamina = stamina;
    }
    public virtual void SetStaminaRegen(float stamina)
    {
        staminaRegeneration = stamina;
    }
    public virtual void SetSprintSpeed(float Sprintspeed)
    {
        this.sprintspeed = Sprintspeed;
    }
    public virtual void Iniciate()
    {
        currentHealth = MaxHealth;
        currentStamina = MaxStamina;
    }
}
