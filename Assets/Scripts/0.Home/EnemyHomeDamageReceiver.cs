using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeDamageReceiver : DamageReceiver
{
    [SerializeField] private EnemyHomeCtrl enemyHomeCtrl;
    [SerializeField] private EnemyHomeDespawn despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyHomeCtrl();
        LoadDespawn();
    }

    private void LoadEnemyHomeCtrl()
    {
        if (enemyHomeCtrl != null) return;
        enemyHomeCtrl = GetComponentInParent<EnemyHomeCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyHomeCtrl()", gameObject);
    }

    private void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = enemyHomeCtrl.GetComponentInChildren<EnemyHomeDespawn>();
        Debug.LogWarning(transform.name + ": LoadDespawn()", gameObject);
    }

    protected override void OnDead()
    {
        EnemyHomeManager.Instance.OnHomeDestroy();
        despawn.DespawnObject();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        baseMaxHP = 10f;
    }
}
