using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControll : MonoBehaviour
{
    public GameObject airShip;

    public GameObject player;

    public GameObject handWheelTrigger;

    private bool isPlayerEnter = false;

    public AirshipTest ShipController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player(Clone)");

        ShipController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && isPlayerEnter)
        {
            isPlayerEnter = false;

            player.gameObject.GetComponent<PlayerController>().enabled = false;
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;

            ShipController.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !isPlayerEnter)
        {
            isPlayerEnter = true;

            player.gameObject.GetComponent<PlayerController>().enabled = true;
            player.gameObject.GetComponent<PlayerMovement>().enabled = true;

            player.transform.parent = null;
            ShipController.enabled = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerEnter = !isPlayerEnter;


        }
    }

}
