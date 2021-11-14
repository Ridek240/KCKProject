using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

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

    public void TakeDamage(int damage)
    {
        
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth<=0)
        {
            Die();
        }
    }

    public void TakeHeal(int heal)
    {
        heal += armor.GetValue();
        heal = Mathf.Clamp(heal, 0, int.MaxValue);

        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
        Debug.Log(transform.name + " takes " + heal + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died"); 
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetMaxHealth()
    {
        return MaxHealth;
    }
}
