using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMov : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpF;
    [SerializeField] public float moveX;
    [SerializeField] public float moveY;
    [SerializeField] public bool checkGround;

    [SerializeField] public bool isFacingRight;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 moveDirection;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        
    }
    public void Update()
    {
        Move();
    }

    private void SetMove(InputAction.CallbackContext value) 
    { 
        moveDirection = value.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            checkGround = false;
        }
    }

    public void Move()
    {

        Control();

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        
        moveDirection = new Vector2(moveX, moveY);
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

    }

    private void Control()
    {
        Jump();

        if (moveX > 0 && isFacingRight == false)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight == true)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpF * 10));
        }
    }

    void Flip() 
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
