using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHomeDespawn : Despawn
{
    protected override bool CanDespawn()
    {
        return false;
    }

}
