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
    

    private void Awake()
    {
        this.rBody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(this.jumpKey))
        {
            if (isGrounded)
            {
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
        isColliding = Physics2D.OverlapCircle(collisionCheck.position, 0.01f, obstacleLayer);
    }

    private void Jump()
    {
        this.rBody.velocity = Vector2.up * jumpStrength;
        AudioController.instance.PlayOneShot(audioJump);
    }
}
