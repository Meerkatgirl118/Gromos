using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerMovement playerMovement;
    Animator animator;
    public int enemyHearts = 3;
    public bool enemyAttacking = false;
    public bool enemyTouchingPlayer = false;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (enemyHearts < 1)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !enemyAttacking)
        {
            enemyTouchingPlayer = true;
            if (playerMovement.walkingLeft)
            {
                animator.SetBool("enemyAttackingRight", true);
                animator.SetBool("enemyAttackingLeft", false);
            }
            if (playerMovement.walkingRight)
            {
                animator.SetBool("enemyAttackingLeft", true);
                animator.SetBool("enemyAttackingRight", false);
            }
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyTouchingPlayer = false;
        }
    }

    public void DecreasePlayerHealth()
    {
        if (enemyTouchingPlayer)
        {
            playerManager.playerHealth--;
        }
    }
}
