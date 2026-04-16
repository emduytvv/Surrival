using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementFollowEnemy : BulletMovementFollowTarget
{
    protected override bool CheckTargetEnable()
    {
        if (target == null) return false;
        EnemyBaseCtrl enemyBaseCtrl = target.parent.GetComponent<EnemyBaseCtrl>();
        if (!enemyBaseCtrl.IsAlive) return false;
        return true;
    }
}
