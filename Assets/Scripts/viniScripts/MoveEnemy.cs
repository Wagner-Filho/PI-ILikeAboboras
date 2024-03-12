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

    private Transform _target;
    [SerializeField] float _distPlayer;

    [SerializeField] float _distance;

    [SerializeField] float _vdis;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {


        //        if (Vector2.Distance(_target.position, transform.position) < _distance)
        //        {
        //            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        //        }
        _distPlayer = Vector2.Distance(_target.position, transform.position);

        if (_distPlayer < _vdis)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed*Time.deltaTime);
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
