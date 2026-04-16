using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHomeShootingEnemy : DamageSender

{
    protected override void ResetValue()
    {
        base.ResetValue();
        damage = 5f;
    }
    public virtual void Fire(Transform currentTarget)
    {
        Transform enemyTarget = currentTarget.transform;
        Vector3 startPoint = transform.parent.position;
        startPoint.y += 3f;
        BulletSpawner.Instance.SpawnBulletFollowTarget(startPoint, enemyTarget, "BulletFollowEnemy", damage);
    }

    public override void Send()
    {
        throw new NotImplementedException();
    }
}
