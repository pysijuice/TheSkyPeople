using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{

    [Header("Up and Down setings:")]
    [SerializeField] float speed;
    [SerializeField] float amplitude;
    [SerializeField] float defaultYObjectPosition;
    void Start(){
        defaultYObjectPosition = transform.position.y;
        speed = Random.Range(0,0.3f);
        amplitude = Random.Range(5,20);
    }
    void Update()
    {
        
        ChangePosition();
    }

    void ChangePosition()
    {
        transform.position = new Vector3(transform.position.x, defaultYObjectPosition + Mathf.Sin(Time.fixedTime * speed) * amplitude, transform.position.z);

    }

}
