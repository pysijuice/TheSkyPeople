using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HedhedogAI : MonoBehaviour
{
    public float speed;
    private Transform airShip;
    void Start()
    {
        airShip = GameObject.FindGameObjectWithTag("AirShip").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, airShip.position, speed * Time.deltaTime);
    }
}
