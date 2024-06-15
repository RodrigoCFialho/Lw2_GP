using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mines : MonoBehaviour
{
    protected Rigidbody2D myRigidbody2D;

    protected CircleCollider2D myCircleCollider2D;

    protected void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
    }

    protected abstract void OnCollisionEnter2D(Collision2D other);

    protected void Explode()      // public ou protected? :/
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
