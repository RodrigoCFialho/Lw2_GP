using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMine : Mines
{
   [SerializeField]
    private int damage = 10;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            other.gameObject.GetComponent<Movement>().ToogleSpeed();
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
