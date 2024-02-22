using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public int lifecount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            lifecount++;
        }
    }
}
