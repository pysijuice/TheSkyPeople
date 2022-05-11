using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RotatePropeller : MonoBehaviour
{

    [Header("Rotation Speed")]
    [SerializeField] private float speedZ;

    [SerializeField] private GameObject shipController;
    
    private float shipSpeed;
    private AirshipTest AirshipScript;
    

    private void Start()
    {
        AirshipScript = shipController.GetComponent<AirshipTest>();

    }

    // Update is called once per frame
    void Update()
    {
        SpeedOfShip();
    }

    void SpeedOfShip()
    {
        float shipSpeed = AirshipScript.moveForward;
        switch (shipSpeed)
        {
            case 0f:
                transform.Rotate(0, 0, speedZ * 50*Time.deltaTime);
                break;
            case 0.25f:
                transform.Rotate(0, 0, speedZ * 100*Time.deltaTime);
                break;
            case 0.5f:
                transform.Rotate(0, 0, speedZ * 200*Time.deltaTime);
                break;
            case 0.75f:
                transform.Rotate(0, 0, speedZ * 300*Time.deltaTime);
                break;
            case 1f:
                transform.Rotate(0, 0, speedZ * 400*Time.deltaTime);
                break;
            case -0.25f:
                transform.Rotate(0, 0, speedZ * -100*Time.deltaTime);
                break;
            case -0.5f:
                transform.Rotate(0, 0, speedZ * -200*Time.deltaTime);
                break;
            case -0.75f:
                transform.Rotate(0, 0, speedZ * -300*Time.deltaTime);
                break;
            case -1f:
                transform.Rotate(0, 0, speedZ * -400*Time.deltaTime);
                break;
        }
    }
}
