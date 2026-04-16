using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ObjectAbstract
{
    [SerializeField] protected float moveSpeed = 1f;
    public float MoveSpeed => moveSpeed;
    public virtual void SetSpeedMove(float speedMove)
    {
        this.moveSpeed = speedMove;
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        // this.moveSpeed = ObjectCtrl?.StatsSO?.moveSpeed ?? this.moveSpeed;
    }
    protected virtual void Moving()
    {
        //For override
    }
}
