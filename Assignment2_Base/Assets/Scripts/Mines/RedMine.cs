using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMine : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private int damage = 10;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            other.gameObject.GetComponent<Movement>().ToogleSpeed();
            Explode();
        }
    }

    public void Explode()
    {
        gameObject.GetComponent<ExplosionEffect>().Explode();
        myRigidbody2D.simulated = false;
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
