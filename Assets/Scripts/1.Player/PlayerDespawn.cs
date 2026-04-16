using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDespawn : Despawn
{
    protected override bool CanDespawn()
    {
        return false;
    }
    public override void DespawnObject()
    {
        
    }
}
