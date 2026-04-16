using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectLookAtTarget360 : ObjectLookAtTarget
{
    [SerializeField] protected float speedRotate = 10f;

    public virtual void SetSpeedMove(float speedRotate)
    {
        this.speedRotate = speedRotate;
    }
    protected override void LootAtTarget()
    {
        if (!target) return;
        Vector3 diff = this.target.position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rot_z);
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, this.speedRotate);
    }

}
