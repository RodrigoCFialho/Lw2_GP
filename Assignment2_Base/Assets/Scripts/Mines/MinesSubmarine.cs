using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinesSubmarine : Mines
{
    protected override void OnContact(GameObject player)
    {
        ApplyEffect(player);
    }

    protected abstract void ApplyEffect(GameObject player);

    private void OnTriggerEnter2D(Collider2D other)
    {
        Explode();
    }
}
