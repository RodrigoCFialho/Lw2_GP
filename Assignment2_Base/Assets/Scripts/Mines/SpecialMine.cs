using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMine : Mines
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShipLaunch>().Launch();
            Explode();
        }
        else if (other.gameObject.CompareTag("Submarine"))
        {
            //mine launch
            Explode();
        }
    }
}
