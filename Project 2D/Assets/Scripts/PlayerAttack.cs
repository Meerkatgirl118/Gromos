using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Enemy enemy;
    PlayerMovement playerMovement;
    Animator animator;

    public bool attackActive = false;
    public bool touchingEnemy = false;
    public float postAttackWaittime = 1f;
    public bool postAttackWaittimeActive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.AltGr) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            attackActive = true;
            AttackAnimation();
        }
        else
        {
            attackActive = false;
        }
    }

    void LateUpdate()
    {
        if (touchingEnemy == true)
        {
            TouchingEnemy();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            touchingEnemy = true;
            TouchingEnemy();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            touchingEnemy = false;
        }
    }

    void TouchingEnemy()
    {
        if (touchingEnemy == true && !postAttackWaittimeActive)
        {
            AttackAnimation();
        }
    }

    void AttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.AltGr) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (playerMovement.facingRight) { animator.SetBool("leftPunch", false); animator.SetBool("rightPunch", true); }
            else if (playerMovement.facingLeft) { animator.SetBool("rightPunch", false); animator.SetBool("leftPunch", true); }
            else { animator.SetBool("rightPunch", true); }
        }
    }

    public void AttackEnemy()
    {
        if (touchingEnemy == true)
        {
            enemy.enemyHearts--;
        }
        postAttackWaittimeActive = true;
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        if (playerMovement.facingRight) { animator.SetBool("rightPunch", false); }
        else if (playerMovement.facingLeft) { animator.SetBool("leftPunch", false); }
        else { animator.SetBool("rightPunch", false); animator.SetBool("leftPunch", false); }
        yield return new WaitForSeconds(postAttackWaittime);
        postAttackWaittimeActive = false;
    }
}
