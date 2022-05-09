using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float yMaxVelocity;
    public float jumpHeight = 3f;
    public GameObject camera;
    


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Animator animPlayer;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame


    private void Start()
    {

        animPlayer = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            animPlayer.SetBool("isWalking", true);
        }
        else
        {
            animPlayer.SetBool("isWalking", false);

        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            animPlayer.SetBool("isJumping", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        } else if(!Input.GetButtonDown("Jump") && isGrounded)
        {
            animPlayer.SetBool("isJumping", false);
        }

        velocity.y += gravity * Time.deltaTime;
        if (velocity.y < yMaxVelocity){
            velocity.y = yMaxVelocity;
        }

        controller.Move(velocity * Time.deltaTime);
    }

}
