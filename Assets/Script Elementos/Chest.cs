using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private DropItens dropScript;
    [SerializeField] private bool colPlayer;
    bool itemPego;
    [SerializeField] GameObject Particula;
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
        if(other.gameObject.tag == "Player" && itemPego==false)
        {
            colPlayer= false;
            itemPego = true;
            dropScript.Drop();
            Particula.SetActive(true);
        }
    }
}
