using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectLookByDirection : SaiMonoBehaviour
{
    [SerializeField] protected Vector3 direction;
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        LookDirection();
    }
    protected virtual void LookDirection()
    {
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rot_z);
        transform.parent.rotation = targetRotation;
    }

}
