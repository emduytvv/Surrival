using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHpMovement : MovementToTarget
{
    protected override void Moving()
    {
        if (!target) return;
        transform.parent.position = target.position + Vector3.up * 3.2f;
    }
}
