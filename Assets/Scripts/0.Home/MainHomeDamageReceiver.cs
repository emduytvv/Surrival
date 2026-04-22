using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHomeDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        OnGameOver();
    }

    private void OnGameOver()
    {
        GameOverManager.Instance.OnGameOver();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        baseMaxHP = 100f;
    }
}
