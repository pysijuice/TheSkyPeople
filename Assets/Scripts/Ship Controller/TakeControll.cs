    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControll
{
    private GameObject player;

    private GameObject wheel;

    public AirshipTest ShipController;
    // Start is called before the first frame update

    // Update is called once per frame
    /*void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && isPlayerEnter)
        {
            isPlayerEnter = !isPlayerEnter;

            player.gameObject.GetComponent <PlayerMovement>().enabled = false;
            player.gameObject.GetComponent<CharacterController>().enabled = false;


            player.transform.parent = transform;
            ShipController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !isPlayerEnter)
        {
            isPlayerEnter = !isPlayerEnter;

            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
            player.gameObject.GetComponent<CharacterController>().enabled = true;


            player.transform.parent = null;
            ShipController.enabled = false;

        }
    }*/

    public void EnterInWheel(bool isPlayerEnter)
    {
        ShipController = GameObject.Find("Ship Controller").GetComponent<AirshipTest>();
        ShipController.enabled = false;
        wheel = GameObject.Find("Wheel");
        player = GameObject.Find("Player");
        if (Input.GetKeyDown(KeyCode.F) && !isPlayerEnter)
        {

            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            player.gameObject.GetComponent<CharacterController>().enabled = false;

            
            player.transform.parent = wheel.transform;
            // + вектор это оффсет для  позиции относительно руля
            player.transform.position = wheel.transform.position + new Vector3(2,0,0);
            ShipController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && isPlayerEnter)
        {

            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
            player.gameObject.GetComponent<CharacterController>().enabled = true;


            player.transform.parent = null;
            ShipController.enabled = false;

        }
    }

}
