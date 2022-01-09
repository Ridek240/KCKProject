using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats// : MonoBehaviour
{
    public BarSystem barSystem;
    public int MaxHealth = 100;
    public int currentHealth { get; private set; }

    public bool Alife;

    public float speed = 12f;
    public float jumpHeight = 2f;
    public float MaxStamina = 200;
    public float currentStamina;

    public float sprintspeed = 30f;

    public Stat damage;
    public Stat armor;
    /*
    protected void Awake()
    {
        currentHealth = MaxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
    }
    //*/
    public virtual void UpdateStamina()
    {
        currentStamina += 0.5f;
        currentStamina = Mathf.Clamp(currentStamina, 0f, MaxStamina);
    }

    public virtual void UpdateStats()
    {
        barSystem = GUIManager.GetInstance().GetBarSystem();
        barSystem.SetMaxStats(MaxHealth, MaxStamina);
        barSystem.SetStamina(currentStamina);
    }

    public virtual void TakeDamage(int damage)
    {
        
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        //Debug.Log(transform.name + " takes " + damage + " damage.");



        Alife = true;
        if (currentHealth <= 0)
        {
            Alife = false;
        }
    }

    public virtual void TakeHeal(int heal)
    {
        heal += armor.GetValue();
        heal = Mathf.Clamp(heal, 0, int.MaxValue);

        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
        //Debug.Log(transform.name + " takes " + heal + " damage.");
        Alife = true;
        if (currentHealth <= 0)
        {
            Alife = false;
        }
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
    public virtual void Die()
    {
        //Debug.Log(transform.name + " died"); 
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
}
