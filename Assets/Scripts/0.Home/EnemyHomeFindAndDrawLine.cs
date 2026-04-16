using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeFindAndDrawLine : FindAndDrawLine
{
    [SerializeField] protected EnemyHomeCtrl enemyHomeCtrl;
    public EnemyHomeCtrl EnemyHomeCtrl => enemyHomeCtrl;

    protected override void Awake()
    {
        base.Awake();
        hightOfHome = 2f;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyHomeCtrl();
    }
    protected override void LoadLayerMaskName()
    {
        LayerMaskName = "Player";
    }
    private void LoadEnemyHomeCtrl()
    {
        if (enemyHomeCtrl != null) return;
        enemyHomeCtrl = transform.parent.GetComponent<EnemyHomeCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyHomeCtrl()", gameObject);
    }
    protected override bool CheckAlive()
    {
        if (currentTarget == null) return false;
        PlayerCtrl playerCtrl = currentTarget.parent.GetComponent<PlayerCtrl>();
        if (!playerCtrl.isAlive) return false;
        return true;
    }
    protected override void Attack()
    {
        enemyHomeCtrl.EnemyHomeShooting.Fire(currentTarget);
    }
}
