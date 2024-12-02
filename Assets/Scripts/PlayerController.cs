using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float distance;
    [SerializeField] private Vector3 offset;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private Animator animator;
    private RaycastHit2D hit;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }     

    private void Move()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
            CheckObstacle(Vector2.right);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            CheckObstacle(Vector2.left);
        }


        if (hit != true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }   
    }

    private void CheckObstacle(Vector2 direction)
    {
        hit = Physics2D.Raycast(transform.position + offset, direction, distance, groundLayer);
        Debug.DrawRay(transform.position + offset, direction * distance, Color.red);        
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
