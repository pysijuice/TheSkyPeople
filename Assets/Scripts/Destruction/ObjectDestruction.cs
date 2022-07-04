using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    HealthSystem healthSystem = new HealthSystem(100);
    [SerializeField] GameObject Desctructed;
    [SerializeField] GameObject item;
    [SerializeField] float breakForce = 1;
    
    public void Damage(int damage)
    {
        healthSystem.Damage(damage);
        Debug.Log(healthSystem.GetHealth());
        if(healthSystem.GetHealth() == 0)
        {
            SpawnItem();
            if (Desctructed != null)
            {
                GameObject frac = Instantiate(Desctructed, transform.position, transform.rotation);
                foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
                {

                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                StartCoroutine(DeleteDestruction(frac));
            }
            else
            {
                Destroy(gameObject);
            }


        }
    }
    private void SpawnItem()
    {
        Instantiate(item, transform.position, transform.rotation);
    }
    
    IEnumerator DeleteDestruction(GameObject frac)
    {
        gameObject.transform.localScale -= new Vector3(30, 30, 30);
        Debug.Log("1");

        yield return new WaitForSeconds(4);
        Destroy(frac);
        Debug.Log("2");
        Destroy(gameObject);

    }




}
