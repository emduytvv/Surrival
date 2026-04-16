using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeDespawn : Despawn
{
    protected override bool CanDespawn()
    {
        return false;
    }

}
