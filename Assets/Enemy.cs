using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    HealthSystem healthSystem = new HealthSystem(100);

    public void Damage(int damage)
    {
        healthSystem.Damage(damage);
        if(healthSystem.GetHealth() == 0)
        {
            Destroy(gameObject);
        }
    }
    

    
}
