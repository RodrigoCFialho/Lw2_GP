using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMine : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    private CircleCollider2D myCircleCollider2D;

    [SerializeField]
    private int damage = 20;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Explode();
        }
    }

    public void Explode()
    {
        gameObject.GetComponent<ExplosionEffect>().Explode();
        myRigidbody2D.simulated = false;
        myCircleCollider2D.enabled = false;
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
