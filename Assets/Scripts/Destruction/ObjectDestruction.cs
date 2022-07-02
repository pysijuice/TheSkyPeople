using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    HealthSystem healthSystem = new HealthSystem(100);
    public GameObject Desctructed;
    public float breakForce = 1;
    
    public void Damage(int damage)
    {
        healthSystem.Damage(damage);
        Debug.Log(healthSystem.GetHealth());
        if(healthSystem.GetHealth() == 0)
        {
            GameObject frac = Instantiate(Desctructed, transform.position, transform.rotation);
            foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
            {
                Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                rb.AddForce(force);
            }
            Destroy(gameObject);
        }
    }
      
    
    
    
}
