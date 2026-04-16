using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToTarget : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected Vector3 offset = new Vector3(0, 0, -10);
    protected override void Moving()
    {
        if (!target) return;
        Vector3 desired = target.position + offset;
        desired.z = -10f;
        transform.position = Vector3.Lerp(transform.position, desired, moveSpeed * Time.deltaTime);
    }
    public void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }
}
