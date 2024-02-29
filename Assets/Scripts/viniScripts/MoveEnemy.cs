using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _scaleX;
    [SerializeField] bool _dir;
    [SerializeField] bool _isFacing;

    void Start()
    {

    }
    void Update()
    {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && _dir == false)
        {
            _speed = _speed * -1;
            _scaleX = _scaleX * -1;
            _dir = true;
            Flip();
            //transform.localScale = new Vector2(_scaleX*3, 3);
            Invoke("TimeDir", 0.5f);
        }
    }
    void TimeDir()
    {
        _dir = false;

    }

    public void Flip()
    {
        _isFacing = !_isFacing;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
