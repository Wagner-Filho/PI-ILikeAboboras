using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyHealth eHealth;
    //public float damage;

    [Header("Combate Settings")]
    [SerializeField] private Transform ControladorGolpe;
    [SerializeField] private float raioGolpe;
    [SerializeField] private float danoGolpe;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        other.gameObject.GetComponent<EnemyHealth>().health -= danoGolpe;
    //    }
    //}

    public void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladorGolpe.position, raioGolpe);

        foreach (Collider2D obj in objetos)
        {
            if (obj.CompareTag("Enemy"))
            {
                obj.transform.GetComponent<EnemyHealth>().TakeDamage(danoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(ControladorGolpe.position, raioGolpe);
    }
}
