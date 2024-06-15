using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMine : MinesDamage
{
    [SerializeField]
    private int redDamage = 10;

    [SerializeField]
    private float speedMultiplier = 2;
    protected override void ApplyDamage(Health health)
    {
        health.MineDamage(redDamage);
    }

    protected override void SecondEffect(GameObject player)
    {
        player.GetComponent<Movement>().ToogleSpeed(speedMultiplier);
    }
}
