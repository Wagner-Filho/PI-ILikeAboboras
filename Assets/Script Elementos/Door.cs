using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    public GameObject _collision;
    [SerializeField] private bool colPlayer;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (colPlayer && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colPlayer = true;
            _collision.SetActive(false);
          
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colPlayer = false;
            _collision.SetActive(true);
        }
    }
}