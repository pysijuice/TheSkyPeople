using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpMoney : MonoBehaviour
{
    [SerializeField] GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ship.GetComponent<ResourcesCount>().moneyCount += 1;
            Destroy(gameObject);
        }
    }
}
