using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public float climbSpeed = 5f;
    public GameHandler gameHandler;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        transform.position = new Vector2((float)-5, (float)3);
    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            collision.gameObject.SetActive(false);
            gameHandler.addGem();
        } 
        
        if(collision.CompareTag("Cherry"))
        {
            collision.gameObject.SetActive(false);
            gameHandler.addCherry();
        }

        if(collision.CompareTag("NextLevelCollider"))
        {
            gameHandler.LoadNextLevel();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            animator.SetBool("IsClimbing", true);
            GetComponent<Rigidbody2D>().gravityScale = 0;

            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, climbSpeed);
                animator.SetBool("IsMovingWhileClimbing", true);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -climbSpeed);
                animator.SetBool("IsMovingWhileClimbing", true);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                animator.SetBool("IsMovingWhileClimbing", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            animator.SetBool("IsClimbing", false);
            GetComponent<Rigidbody2D>().gravityScale = 6;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}