using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float WalkSpeed = 12f;
    public float RunSpeed=20f;
    private float Speed;
    public float gravity = -9.81f;
    public Transform groundCheak;
    public float geoundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHight = 3f;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
       Speed = WalkSpeed;
    }
    void Update()
    {
        GroundCheak();
        Jump();
        Gravity();
        Run();
        Move();
    }

    private void Gravity()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y=Mathf.Sqrt(jumpHight * -2f *gravity);
        }
    }
    private void Move()
    {
        float x= Input.GetAxisRaw("Horizontal");
        float z= Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward*z;
        controller.Move(move * Speed*Time.deltaTime);
    }
    private void GroundCheak()
    {
        isGrounded =  Physics.CheckSphere(groundCheak.position,geoundDistance,groundMask);
    }

    private void Run()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed=RunSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed= WalkSpeed;
        }
    }

}
