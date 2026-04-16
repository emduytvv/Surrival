using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMovementFollowTarget : MovementToTarget
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;
    private Vector3 lastDirection = Vector3.right;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }

    private void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl()", gameObject);
    }

    protected override void FixedUpdate()
    {
        if (!CheckTargetEnable()) { this.target = null; }
        TransmitTargetToRotate();
        this.Moving();
    }

    private void TransmitTargetToRotate()
    {
        if (!target)
        {
            bulletCtrl.ObjectLookAtTarget.SetTarget(null);
            return;
        }
        bulletCtrl.ObjectLookAtTarget.SetTarget(target);
    }

    protected abstract bool CheckTargetEnable();
    protected override void Moving()
    {
        Vector3 dir;

        if (target != null)
        {
            dir = (target.position - transform.position).normalized;
            lastDirection = dir;
        }
        else
        {
            dir = lastDirection;
        }
        transform.parent.Translate(dir * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
}
