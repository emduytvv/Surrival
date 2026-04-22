using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHpDespawn : Despawn
{
    protected Transform target;
    public void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }
    protected override bool CanDespawn()
    {
        if (target != null) return false;
        return true;
    }
}
