using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectLookAtTarget : SaiMonoBehaviour
{

    [SerializeField] protected Transform target;
    [SerializeField] protected float deadZoneX = 0.05f;
    protected virtual void FixedUpdate()
    {
        this.LootAtTarget();
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void LootAtTarget()
    {
        if (!target) return;
        Vector3 baseScale = transform.parent.localScale;
        Vector3 diff = this.target.position - transform.parent.position;
        if (Mathf.Abs(diff.x) < deadZoneX) return;

        float sign = diff.x >= 0f ? 1f : -1f;
        transform.parent.localScale = new Vector3(Mathf.Abs(baseScale.x) * sign, baseScale.y, baseScale.z);
    }
}
