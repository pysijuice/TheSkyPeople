using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ditzelgames;
using Photon.Pun;


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
    public float passiveCrenCoef;

    [SerializeField] private GameObject wheelHandle;



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
        Physics.gravity = new Vector3(0, 0, 0);

    }

    void Update()
    {
        RotateWheel();
        upDownInput = Input.GetAxis("ShipUp");
        steer = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        brakeInput = Input.GetAxis("Jump");


        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                moveForward += 0.25f;
                if (moveForward > 1)
                {
                    moveForward = 1;
                }
                Debug.Log(moveForward);
            }
            else
            {
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
        var forward = Vector3.Scale(new Vector3(1, 1, 1), -transform.right);
        //upDown
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * upDownInput * 100 / upDownCoef), Space.Self);

        // //leftRight

        Rigidbody.AddForceAtPosition(-Time.deltaTime * steer * transform.forward * SteerPower / 100f, motor.position);
        Rigidbody.AddForce(transform.forward * steer * 2, ForceMode.Force);
        Rigidbody.AddForceAtPosition(Time.deltaTime * steer * transform.forward * SteerPower / 200f,
        motor.position, ForceMode.Force);

        //forwardBack
        PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed * moveForward, Power);

        //brake
        Rigidbody.AddForce(-brakeInput * 5 * Rigidbody.velocity);
        Rigidbody.AddForce(-0.7f * Rigidbody.velocity);

        if (transform.eulerAngles.x < 180)
        {
            if (transform.eulerAngles.x > 25)
            {
                transform.Rotate(-transform.right * rotationSpeed * Time.deltaTime * passiveCrenCoef * 5, Space.World);
            }
            transform.Rotate(transform.right * rotationSpeed * Time.deltaTime * -1 * passiveCrenCoef, Space.World);
        }
        else if (transform.eulerAngles.x > 180)
        {
            if (transform.eulerAngles.x < 25)
            {
                transform.Rotate(transform.right * rotationSpeed * Time.deltaTime * passiveCrenCoef * 5, Space.World);
            }
            transform.Rotate(transform.right * rotationSpeed * Time.deltaTime * passiveCrenCoef, Space.World);

        }

    }

    void RotateWheel()
    {
        if (Input.GetKey(KeyCode.A))
        {
            wheelHandle.transform.Rotate(0, 0, 50 * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D))
        {
            wheelHandle.transform.Rotate(0, 0, -50 * Time.deltaTime);
        }
    }

}
