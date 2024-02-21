using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private DropItens dropScript;
    [SerializeField] private bool colPlayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        dropScript = GetComponent<DropItens>();
    }

    void Update()
    {
        if (colPlayer && Input.GetKeyDown(KeyCode.E))
        {
            anim.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            colPlayer = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            colPlayer= false;
            dropScript.Drop();
        }
    }
}
