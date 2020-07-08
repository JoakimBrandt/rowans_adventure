using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    private float deathTime = 0.5f;
    public void TakeDamage()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        // Play death animation

        animator.SetTrigger("Dead");

        // Wait for animation to finish

        yield return new WaitForSeconds(deathTime);

        // Disable object and colliders
        gameObject.SetActive(false);
    }
}
