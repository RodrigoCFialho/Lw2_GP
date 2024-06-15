using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMine : Mines
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShipLaunch>().RestoreStock();
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
