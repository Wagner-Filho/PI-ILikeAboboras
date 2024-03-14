using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [Header("Walk Settings")]
    float speed = 4.5f;
    bool isFacing,
         isWalking = false,
         CheckAttack;

    public Rigidbody2D rig;
    public Vector2 moveDirection;
    public Animator playerAnimator;

    [Header("Dash Settigns")]
    float dashSpeed = 15f;
    float dashDuration = 0.3f;
    float dashCooldown = 0.5f;
    bool isDashing;
    bool canDash;

    //Executa primeiro que Start
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    //Executa apartir do Start
    private void Start()
    {
        isWalking = false;
        isDashing = false;
        canDash = true;
    }

    //Input novo para movimento
    public void SetMove(InputAction.CallbackContext value)

    {
        moveDirection = value.ReadValue<Vector2>();
    }

    //Input novo para Dash
    public void SetDash(InputAction.CallbackContext value)
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }

    //Input novo para Attack
    public void SetAttack(InputAction.CallbackContext value)
    {
        CheckAttack = true;
    }

    private void Update()
    {
        MoveP();
    }

    private void MoveP()
    {
        //rig.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        //isWalking = (moveDirection.x != 0 || moveDirection.y != 0);
        
        if (isDashing)
        {
            return;
        }

        if (CheckAttack)
        {
            rig.velocity = Vector2.zero;
            isWalking = false;
        }
        else
        {
            rig.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
            isWalking = (moveDirection.x != 0 || moveDirection.y != 0);
        }

        if (isWalking)
        {
            playerAnimator.SetFloat("moveX", moveDirection.x);
            playerAnimator.SetFloat("moveY", moveDirection.y);
        }

        playerAnimator.SetBool("isWalking", isWalking);

       if (moveDirection.x < 0 && isFacing == false)
        {
            Flip();
        }
       else if (moveDirection.x > 0 && isFacing == true)
       {
            Flip();
       }

        playerAnimator.SetBool("Attack", CheckAttack);

    }

    public void checkAttack()
    {
        CheckAttack = false;
    }

    public void Flip()
    {
       isFacing = !isFacing;
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rig.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
