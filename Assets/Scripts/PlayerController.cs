using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Move();
        Jump();

        
    }     

    private void Move()
    {   
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
                        
        if (moveInput > 0)
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        else if (moveInput < 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void Jump()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") & isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    
}
