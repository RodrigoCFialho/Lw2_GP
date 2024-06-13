using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinesAirplane : Mines
{
    protected override void OnContact(GameObject player)
    {
        ApplyEffects(player);
    }

    protected abstract void ApplyEffects(GameObject player);
}
