using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinesDamage : MinesSubmarine
{
    protected override void ApplyEffect(GameObject player)
    {
        Health health = player.GetComponent<Health>();
        ApplyDamage(health);
        SecondEffect(player);
    }
    protected abstract void ApplyDamage(Health health);

    protected virtual void SecondEffect(GameObject player) { }
}
