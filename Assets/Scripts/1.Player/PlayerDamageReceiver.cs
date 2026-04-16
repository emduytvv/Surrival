using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {

    }
    protected override void ResetValue()
    {
        base.ResetValue();
        baseMaxHP = 100f;
    }
}
