using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RotatePropeller : MonoBehaviour
{

    [Header("Rotation Speed")]
    [SerializeField] private float speedX;

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
                transform.Rotate(speedX * 50 * Time.deltaTime, 0, 0);
                break;
            case 0.25f:
                transform.Rotate(speedX * 100 * Time.deltaTime, 0, 0);
                break;
            case 0.5f:
                transform.Rotate(speedX * 200 * Time.deltaTime, 0, 0);
                break;
            case 0.75f:
                transform.Rotate(speedX * 300 * Time.deltaTime, 0, 0);
                break;
            case 1f:
                transform.Rotate(speedX * 400 * Time.deltaTime, 0, 0);
                break;
            case -0.25f:
                transform.Rotate(speedX * -100 * Time.deltaTime, 0, 0);
                break;
            case -0.5f:
                transform.Rotate(speedX * -200 * Time.deltaTime, 0, 0);
                break;
            case -0.75f:
                transform.Rotate(speedX * -300 * Time.deltaTime, 0, 0 );
                break;
            case -1f:
                transform.Rotate(speedX * -400 * Time.deltaTime, 0, 0);
                break;
        }
    }
}
