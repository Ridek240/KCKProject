using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterStats characterStats;
    // Start is called before the first frame update
    void Start()
    {

        //characterStats = gameObject.GetComponent(typeof(CharacterStats)) as CharacterStats;
        Debug.Log(characterStats.GetMaxHealth() + "predeco");
        CharacterStats characterStats1 = new HealthBuff(characterStats,1.5f);
        Debug.Log(characterStats1.GetMaxHealth() + "postdeco");
        
        characterStats = new HealthBuff(characterStats1,2f);
    }

    
        private void Update()
    {

    }


}
