using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementFollowPlayer : BulletMovementFollowTarget
{
    protected override bool CheckTargetEnable()
    {
        if (target == null) return false;
        PlayerCtrl playerCtrl = target.parent.GetComponent<PlayerCtrl>();
        if (!playerCtrl.isAlive) return false;
        return true;
    }
}
