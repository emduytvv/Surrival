using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndDrawLine : FindTargetObject
{
    protected float hightOfHome = 3f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLineRenderer();

    }
    private void LoadLineRenderer()
    {
        if (line == null) line = GetComponent<LineRenderer>();
        if (line != null)
        {
            line.positionCount = 2;
            line.enabled = false;
        }
    }
    protected virtual void Update()
    {
        if (CheckCurrentTarget())
        {
            line.enabled = true;
            return;
        }
        FindEnemyInRange();
    }
    protected void LateUpdate()
    {
        DrawLineTarget();
    }
    protected void DrawLineTarget()
    {
        if (currentTarget == null) return;
        if (line != null)
        {
            line.enabled = true;
            Vector3 a = transform.position;
            a.z = 0f;
            a.y += hightOfHome;
            Vector3 b = currentTarget.position; b.z = 0f;

            line.SetPosition(0, a);
            line.SetPosition(1, b);
        }
        timer += Time.deltaTime;
        if (timer < timerMax) return;
        timer = 0f;
        Attack();

    }

    protected virtual void Attack()
    {
        //ForOverride
    }

    protected override void LoadLayerMaskName()
    {
        //override
    }
}
