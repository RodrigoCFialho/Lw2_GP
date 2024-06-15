using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMine : Mines
{
    [SerializeField]
    private int damage = 20;

    [SerializeField]
    private float checkRadius = 1.5f;

    [SerializeField]
    private LayerMask mineLayer;

    protected override void OnCollisionEnter2D(Collision2D other)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sky"))
        {
            Explode();
        }
    }
}
