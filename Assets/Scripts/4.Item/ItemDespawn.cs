using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : Despawn
{
    protected override bool CanDespawn()
    {
        return false;
    }
    public override void DespawnObject()
    {
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
