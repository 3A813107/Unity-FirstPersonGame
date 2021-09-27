using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheak;
    public float geoundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHight = 3f;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded =  Physics.CheckSphere(groundCheak.position,geoundDistance,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x= Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward*z;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y=Mathf.Sqrt(jumpHight * -2f *gravity);
        }

        controller.Move(move * Speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
