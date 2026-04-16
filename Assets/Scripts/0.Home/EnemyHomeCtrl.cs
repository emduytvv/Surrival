using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeCtrl : ObjectCtrl
{
    [SerializeField] protected EnemyHomeShooting enemyHomeShooting;
    public EnemyHomeShooting EnemyHomeShooting => enemyHomeShooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyHomeShooting();
    }
    private void LoadEnemyHomeShooting()
    {
        if (enemyHomeShooting != null) return;
        enemyHomeShooting = GetComponentInChildren<EnemyHomeShooting>();
        Debug.LogWarning(transform.name + ": LoadEnemyHomeShooting()", gameObject);
    }
}
