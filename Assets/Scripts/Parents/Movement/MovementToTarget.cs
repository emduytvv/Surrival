using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToTarget : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void Moving()
    {
        if (!target) return;
        Vector3 desired = target.position;
        transform.position = Vector3.Lerp(transform.position, desired, moveSpeed * Time.fixedDeltaTime);
    }
    public void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }
}
