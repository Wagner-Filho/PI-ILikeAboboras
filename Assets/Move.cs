using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
     
     float speed = 7; 
     bool isFacing, 
     isWalking = false;

    Rigidbody2D rig;
    public Vector2 moveDirection;
    public Animator playerAnimator;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        isWalking = false;
    }

    public void SetMove(InputAction.CallbackContext value)

    {
        moveDirection = value.ReadValue<Vector2>();
    }

    private void Update()
    {
        MoveP();
    }

    private void MoveP()
    {
        rig.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        isWalking = (moveDirection.x != 0 || moveDirection.y != 0);

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
    }

    public void Flip()
    {
       isFacing = !isFacing;
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
    }

}
