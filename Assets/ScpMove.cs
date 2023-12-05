using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScpMove : MonoBehaviour
{
    [SerializeField] float speed, jumpF;
    [SerializeField] bool checkJump, isFacing;

    Rigidbody2D rig;
    Vector2 moveDirection;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
    }

    public void SetJump(InputAction.CallbackContext value) 
    {
        if (checkJump)
        {
            rig.AddForce(Vector2.up * 10 * jumpF);
            //checkJump = false;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rig.velocity = new Vector2(moveDirection.x * speed, rig.velocity.y);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            checkJump = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkJump = false;
        }
    }


}
