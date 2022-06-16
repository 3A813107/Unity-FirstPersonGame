using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    #region 
    public static Transform instance;
    private void Awake()
    {
        instance = this.transform;
    }

    #endregion


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

    public Vector3 velocity;
    bool isGrounded;

    public GameObject footstep;

    [Header("Animation")]
    private Animator anim;

    void Start()
    {
       anim=GetComponentInChildren<Animator>();
       Speed = WalkSpeed;
    }
    void Update()
    {
        if(!GameManager.isPause && !GameManager.instance.PlayerDie)
        {
            Jump();
            Run();
            Move();
            HandleAnimation();
            Gravity();            
        }
        GroundCheak();
        
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
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y=Mathf.Sqrt(jumpHight * -2f *gravity);
            footstep.SetActive(false);
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
        if(Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
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
            footstep.SetActive(false);
        }
        else if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed",0.5f,0.1f,Time.deltaTime);
            footstep.SetActive(true);
            footstep.GetComponent<AudioSource>().pitch=0.9f;
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("Speed",1f,0.1f,Time.deltaTime);
            footstep.SetActive(true);
            footstep.GetComponent<AudioSource>().pitch=1.3f;
        }
    }

}
