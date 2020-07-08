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

    [SerializeField] float invincibilityDeltaTime = 0.15f;
    [SerializeField] float invincibilityTime = 1.5f;
    [SerializeField] float thrust = 30.0f;
    [SerializeField] float tookDamageThrust = 65.0f;
    [SerializeField] Renderer renderer;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isInvincible = false;

    private void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        transform.position = new Vector2((float)-5, (float)3);
        gameHandler.sceneLoader.fadeOut();
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

        if(collision.CompareTag("BottomLimitDeath"))
        {
            gameHandler.GameOver();
        }


        if(collision.CompareTag("Enemy"))
        {
            if(collision is CircleCollider2D)
            {
                if(!isInvincible)
                {
                    animator.SetTrigger("TookDamage");
                    Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
                    GetComponent<Rigidbody2D>().AddForce(pushDirection * tookDamageThrust, ForceMode2D.Impulse);
                    gameHandler.takeDamage();

                    StartCoroutine(BecomeInvincible());
                }
            } 
            else if(collision is BoxCollider2D)
            {
                collision.GetComponent<Enemy>().TakeDamage();
                GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
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

    private IEnumerator BecomeInvincible()
    {
        Debug.Log("Invincible");
        isInvincible = true;

        for (float i = 0; i < invincibilityTime; i += invincibilityDeltaTime)
        {
            
            if(renderer.material.color == Color.white)
            {
                renderer.material.color = Color.red;
            } else
            {
                renderer.material.color = Color.white;
            }

            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Not invincible");
        isInvincible = false;
        renderer.material.color = Color.white;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}