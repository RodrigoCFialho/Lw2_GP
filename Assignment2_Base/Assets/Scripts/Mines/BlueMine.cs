using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMine : MinesSubmarine
{
    protected override void ApplyEffect(GameObject player)
    {
        
    }

    protected override void StopFalling()
    {
        mineRigidBody.simulated = false;
    }
}
