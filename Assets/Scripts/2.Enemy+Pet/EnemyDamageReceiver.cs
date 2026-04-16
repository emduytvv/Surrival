using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
        LoadMaxHP();
    }

    private void LoadMaxHP()
    {
        maxHP = enemyCtrl.EnemyData.maxHP;
    }

    private void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    protected override void OnDead()
    {
        enemyCtrl.SetisAlive(false);
        enemyCtrl.EnemyAnimation.PlayDead();
    }
    protected override void Reduce(float damage)
    {
        currentHp -= damage;
        CheckHp();
        if (IsDead()) return;
        enemyCtrl.EnemyAnimation.PlayHurt();
    }
}
