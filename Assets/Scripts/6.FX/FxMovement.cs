using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxMovement : MovementToTarget
{
    protected override void Moving()
    {
        if (!target) return;
        Vector3 desired = target.position;
        transform.parent.position = target.position;
    }
}
