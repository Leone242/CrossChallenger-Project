using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wolf : MonoBehaviour
{
    private Rigidbody2D rBody;
    [SerializeField]
    private float jumpStrength;
    [SerializeField]
    private KeyCode jumpKey;
    [SerializeField]
    private Manager manager;
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    private bool canDoubleJump;
    [SerializeField]
    private Transform collisionCheck;
    private bool isColliding;
    [SerializeField]
    private LayerMask obstacleLayer;
    [SerializeField]
    private AudioClip audioJump;
    private Animator wolfAnimator;
    private bool canRun;
    

    private void Awake()
    {
        this.rBody = this.GetComponent<Rigidbody2D>();
        this.wolfAnimator = this.GetComponent<Animator>();
    }

    //private void Start()
    //{
    //    this.Run();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(this.jumpKey))
        {
            canRun = false;
            this.wolfAnimator.SetBool("IsRunning", false);

            if (isGrounded && canRun == false)
            {
                this.wolfAnimator.SetBool("IsJumping", true);
                Jump();
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                jumpStrength /= 1.5f;
                Jump();
                canDoubleJump = false;
                jumpStrength *= 1.5f;
            }
            //else
            //{
            //    this.wolfAnimator.SetBool("IsJumping", false);
            //    canRun = true;
            //}
        }
        else
        {
            this.Run();
        }


        if (isColliding)
        {
            Time.timeScale = 0;
            
            isColliding = false;
            
            manager.StopGame();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        isColliding = Physics2D.OverlapCircle(collisionCheck.position, 0.065f, obstacleLayer);
    }

    private void Jump()
    {
        this.rBody.velocity = Vector2.up * jumpStrength;
        AudioController.instance.PlayOneShot(audioJump);
    }

    private void Run()
    {
        this.wolfAnimator.SetBool("IsJumping", false);
        this.wolfAnimator.SetBool("IsRunning", true);
    }
}
