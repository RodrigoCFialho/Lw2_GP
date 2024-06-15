using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMine : Mines
{
    [SerializeField]
    private int purpleDamage = 20;
    protected override void OnContact(GameObject player)
    {
        Health health = player.GetComponent<Health>();
        health.MineDamage(purpleDamage);
    }

    //check se sai do submarino ou airplane?
}
