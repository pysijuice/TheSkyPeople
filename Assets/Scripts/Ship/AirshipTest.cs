using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ditzelgames;


[RequireComponent(typeof(Rigidbody))]
public class AirshipTest : MonoBehaviour
{

    //visible Properties
    public float rotationSpeed;
    public Transform motor; 
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float crenCoef;
    public float upDownCoef;
    public GameObject child;
    public float brakePower;




    private float moveForward = 0;

    //use Componets
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    float steer;
    float verticalInput;
    float upDownInput;
    float brakeInput;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = motor.localRotation;
        Transform zepTransform = gameObject.GetComponent<Transform>(); 
        Physics.gravity = new Vector3(0,0,0);
    }

    void Update(){
        upDownInput = Input.GetAxis("ShipUp");
        Debug.Log(upDownInput);
        steer = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        brakeInput = Input.GetAxis("Jump");
        //upDown
        transform.Rotate(new Vector3(Time.deltaTime*upDownInput*100/upDownCoef,0,0));

        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxisRaw("Vertical")>0){
                moveForward += 0.25f;
                if (moveForward > 1)
                {
                    moveForward = 1;
                } 
                Debug.Log(moveForward);
            }
            else{
                moveForward -= 0.25f;
                if (moveForward < -1)
                {
                    moveForward = -1;
                } 
                Debug.Log(moveForward);
            }
        }
    }
    void FixedUpdate()
    {   
        //default direction
        var forceDirection = transform.forward;
        var forward = Vector3.Scale(new Vector3(1,1,1), transform.forward);
        
        // Debug.Log(forward);
        
        //leftRight
        transform.Rotate(new Vector3(0,0,-steer*5/crenCoef));
        Rigidbody.AddForceAtPosition(-Time.deltaTime*steer * transform.right * SteerPower / 100f, motor.position);
        Rigidbody.AddForce(transform.right*steer*2, ForceMode.Force);
        Rigidbody.AddForceAtPosition(-Time.deltaTime*steer * transform.right * SteerPower / 200f, child.transform.position, ForceMode.Force);

        //forwardBack
        PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed * moveForward, Power);
        // Rigidbody.AddForce(transform.forward * moveForward * MaxSpeed * Time.deltaTime * 10 , ForceMode.Force);

        //brake
        Rigidbody.AddForce(-brakeInput * Rigidbody.velocity);


        if (transform.eulerAngles.z <180){
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * 1f * -1);
        } else if (transform.eulerAngles.z > 180){
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime* 1f);
        }
        
    }
    public void ThrusterUpDown(float input){
        transform.Rotate(new Vector3(input/upDownCoef,0,0));
    }
    public void ThrusterLeftRight(float time){
        transform.Rotate(new Vector3(0,0,-steer/crenCoef));
        Rigidbody.AddForceAtPosition(time*steer * transform.right * SteerPower / 100f, motor.position);
    }
}
