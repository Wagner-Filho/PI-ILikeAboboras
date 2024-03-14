using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [Header("Walk Settings")]
    public Vector2 move;
    public float walkSpeed;
    bool isWalking;
    public Rigidbody2D rb;
    public Animator playerAnimator;
    bool isFacing;

    [Header("Dash Settigns")]
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    bool isDashing;
    bool canDash;
    public Image CooldownBar;
    public float maxCooldown;
    public float coolDownDuration;

    [Header("Attack Settings")]
    bool CheckAttack;
    private EnemyDamage atq;

    void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
        atq.GetComponent<EnemyDamage>();
    }

    void Start()
    {
        isWalking = false;
        isDashing = false;
        canDash = true;
        maxCooldown = dashCooldown;
    }

    void Update()
    {
        Moving();
    //    Dashing();
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    }

    private void Moving()
    {
        if (isDashing)
        {
            return;
        }

        if (CheckAttack)
        {
            rb.velocity = Vector2.zero;
            isWalking = false;
        }
        else
        {
            rb.velocity = new Vector2(move.x * walkSpeed, move.y * walkSpeed);
            isWalking = (move.x != 0 || move.y != 0);
        }

        if (isWalking)
        {
            playerAnimator.SetFloat("moveX", move.x);
            playerAnimator.SetFloat("moveY", move.y);
        }

        playerAnimator.SetBool("isWalking", isWalking);

        if (move.x < 0 && isFacing == false)
        {
            Flip();
        }
        else if (move.x > 0 && isFacing == true)
        {
            Flip();
        }

        playerAnimator.SetBool("Attack", CheckAttack);

        CooldownBar.fillAmount = Mathf.Clamp(dashCooldown / maxCooldown, 0, 1);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(move.x * dashSpeed, move.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        maxCooldown =- 1;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        maxCooldown =+ 1;
        canDash = true;
    }

    public void Flip()
    {
        isFacing = !isFacing;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // private void Dashing()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space) && canDash)
    //     {
    //         StartCoroutine(Dash());
    //     }
    // }

    public void SetDash(InputAction.CallbackContext value)
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void SetAttack(InputAction.CallbackContext value)
    {
        atq.Golpe();
        CheckAttack = true;
    }

    public void checkAttack()
    {
        CheckAttack = false;
    }
}
