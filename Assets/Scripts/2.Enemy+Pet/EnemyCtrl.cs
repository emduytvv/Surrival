using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : EnemyBaseCtrl
{

    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;
    [SerializeField] protected EnemyAnimation enemyAnimation;
    public EnemyAnimation EnemyAnimation => enemyAnimation;
    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;
    [SerializeField] protected EnemyCombat enemyCombat;
    public EnemyCombat EnemyCombat => enemyCombat;
    [SerializeField] protected EnemyDataSO enemyData;
    public EnemyDataSO EnemyData => enemyData;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyMovement();
        LoadEnemyAnimation();
        LoadEnemyDamageReceiver();
        LoadEnemyCombat();
        LoadEnemyDataSO();
    }
    private void LoadEnemyDataSO()
    {
        if (this.enemyData != null) return;
        string resPath = "EnemyData/" + transform.name;
        this.enemyData = Resources.Load<EnemyDataSO>(resPath);
    }
    private void LoadEnemyMovement()
    {
        if (enemyMovement != null) return;
        enemyMovement = GetComponentInChildren<EnemyMovement>();
        Debug.LogWarning(transform.name + ": LoadEnemyMovement()", gameObject);
    }
    private void LoadEnemyCombat()
    {
        if (enemyCombat != null) return;
        enemyCombat = GetComponentInChildren<EnemyCombat>();
        Debug.LogWarning(transform.name + ": LoadEnemyCombat()", gameObject);
    }
    private void LoadEnemyAnimation()
    {
        if (enemyAnimation != null) return;
        enemyAnimation = GetComponentInChildren<EnemyAnimation>();
        Debug.LogWarning(transform.name + ": LoadEnemyAnimation()", gameObject);
    }
    private void LoadEnemyDamageReceiver()
    {
        if (enemyDamageReceiver != null) return;
        enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadEnemyDamageReceiver()", gameObject);
    }
}
