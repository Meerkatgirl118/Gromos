using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    PlayerAttack playerAttack;

    public float moveSpeed = 30f;
    public float runSpeed = 60f;
    public float jumpHeight = 50f;
    public bool walkingLeft;
    public bool walkingRight;
    public bool facingLeft;
    public bool facingRight;

    public bool isGrounded = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
        facingRight = true;
    }

    void Update()
    {
        Jump();
        Move();
    }

    void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Animation();
            rb.AddForce(movement * Time.deltaTime * runSpeed);
        }
        else
        {
            Animation();
            rb.AddForce(movement * Time.deltaTime * moveSpeed);
        }
        if (rb.velocity.magnitude == 0)
        {
            animator.SetBool("walkingLeft", false);
            animator.SetBool("walkingRight", false);
            walkingLeft = false;
            walkingRight = false;
        }

    }

    void Animation()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walkingLeft", true);
            animator.SetBool("walkingRight", false);
            walkingLeft = true;
            walkingRight = false;
            facingLeft = true;
            facingRight = false;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walkingRight", true);
            animator.SetBool("walkingLeft", false);
            walkingRight = true;
            walkingLeft = false;
            facingRight = true;
            facingLeft = false;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isGrounded = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}
