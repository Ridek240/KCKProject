using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth { get; private set; }

    public bool Alife;

    public float speed = 12f;
    public float jumpHeight = 2f;

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

    public virtual void TakeDamage(int damage)
    {
        
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");



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
        Debug.Log(transform.name + " takes " + heal + " damage.");
        Alife = true;
        if (currentHealth <= 0)
        {
            Alife = false;
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died"); 
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
        currentHealth = health;
    }
}
