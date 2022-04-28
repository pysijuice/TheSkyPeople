using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShip : MonoBehaviour
{
    private GameObject airShip;
    private GameObject player;


    private CharacterController rb1;
    private Rigidbody rb2;



    // Start is called before the first frame update
    void Start()
    {

        airShip = GameObject.Find("Speed_Boat");
        player = GameObject.Find("Player");

        rb2 = airShip.GetComponent<Rigidbody>();

    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rb1 = player.GetComponent<CharacterController>();
        }
   
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" )
        {
            rb1.Move(rb2.velocity * Time.deltaTime);
        }
    }
}
