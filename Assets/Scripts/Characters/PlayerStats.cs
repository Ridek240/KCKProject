using UnityEngine;

public class PlayerStats : CharacterStats
{
    
    public PlayerStats() : base()
    {
        MaxHealth = 300;
        currentStamina = MaxStamina;
    }


}
