using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMine : MinesDamage
{
    [SerializeField]
    private int purpleDamage = 20;

    [SerializeField]
    private float checkRadius = 1.5f;

    [SerializeField]
    private LayerMask mineLayer;
    protected override void ApplyDamage(Health health)
    {
        health.MineDamage(purpleDamage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("DepthCharge"))
        {
            Physics2D.OverlapCircleAll(transform.position, checkRadius, mineLayer);
        }
    }
}
