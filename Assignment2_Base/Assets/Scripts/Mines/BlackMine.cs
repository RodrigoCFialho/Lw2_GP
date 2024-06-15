using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMine : Mines
{
    [SerializeField]
    private int damage = 20;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Explode();
        }
        else if (other.gameObject.CompareTag("LowerLimit"))
        {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sky") && wasLaunchedBySubmarine)
        {
            Explode();
        }
    }
}
