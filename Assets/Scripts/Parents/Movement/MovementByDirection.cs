using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementByDirection : Movement
{
    [SerializeField] protected Vector3 direction;
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    protected override void Moving()
    {
        transform.parent.position += direction * moveSpeed * Time.fixedDeltaTime;

    }
}
