using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControll : MonoBehaviour
{
    public GameObject player;
    public GameObject airShip;


    public GameObject handWheelTrigger;

    private bool isPlayerEnter = false;

    public AirshipTest ShipController;
    // Start is called before the first frame update
    void Start()
    {
        ShipController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerEnter && Input.GetKey(KeyCode.F))
        {
            player.gameObject.GetComponent<PlayerController>().enabled = false;
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            handWheelTrigger.SetActive(false);
            player.transform.parent = airShip.transform;
            ShipController.enabled = true;

            
        } else if(Input.GetKey(KeyCode.F))
        {
            player.gameObject.GetComponent<PlayerController>().enabled = true;
            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
            handWheelTrigger.SetActive(true);
            ShipController.enabled = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.F) && !isPlayerEnter)
        {
            isPlayerEnter = true;

            player.gameObject.GetComponent<PlayerController>().enabled = false;
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;

            player.transform.parent = airShip.transform;
            ShipController.enabled = true;
       
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerEnter = false;
        }
    }

}
