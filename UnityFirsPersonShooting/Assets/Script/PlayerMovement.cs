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

    private Vector3 moveDirection;

    public float jumpHight = 3f;

    Vector3 velocity;
    bool isGrounded;

    [Header("Animation")]
    private Animator anim;

    void Start()
    {
       anim=GetComponentInChildren<Animator>();
       Speed = WalkSpeed;
    }
    void Update()
    {
        GroundCheak();
        Jump();
        Gravity();
        Run();
        Move();
        HandleAnimation();
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
        moveDirection = transform.right * x + transform.forward*z;
        controller.Move(moveDirection * Speed*Time.deltaTime);
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

    private void HandleAnimation()
    {
        if(moveDirection == Vector3.zero)
        {
            anim.SetFloat("Speed",0,0.1f,Time.deltaTime);
        }
        else if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed",0.5f,0.1f,Time.deltaTime);
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed",1f,0.1f,Time.deltaTime);
        }
    }

}
