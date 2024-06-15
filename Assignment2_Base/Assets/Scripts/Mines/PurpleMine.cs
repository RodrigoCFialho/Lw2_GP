using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMine : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    private CircleCollider2D myCircleCollider2D;

    [SerializeField]
    private int damage = 20;

    [SerializeField]
    private float checkRadius = 1.5f;

    [SerializeField]
    private LayerMask mineLayer;

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
        else if (other.gameObject.CompareTag("DepthCharge"))
        {
            Collider2D[] mines = Physics2D.OverlapCircleAll(transform.position, checkRadius, mineLayer);

            for (int i = 0; i < mines.Length; ++i)
            {
                //mines[i].gameObject.GetComponent<Mine>().Explode();
            }

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
