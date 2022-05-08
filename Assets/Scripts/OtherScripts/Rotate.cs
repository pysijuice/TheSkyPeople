using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotation Speed")]
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float speedZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime) ;
    }
}
