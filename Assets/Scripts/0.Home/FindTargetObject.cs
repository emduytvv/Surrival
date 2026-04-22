using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FindTargetObject : SaiMonoBehaviour
{
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected float range = 3f;
    public float Range => range;
    [SerializeField] protected Transform currentTarget;
    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float timerMax = 2f;
    [SerializeField] protected string LayerMaskName;
    [SerializeField] protected LineRenderer line;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLayerMaskName();
        LoadEnemyLayer();
    }

    private void LoadEnemyLayer()
    {
        this.enemyLayer = LayerMask.GetMask(LayerMaskName);
    }
    protected abstract void LoadLayerMaskName();

    protected virtual bool CheckCurrentTarget()
    {
        if (!CheckAlive()) return false;
        float currenDistance = Vector3.Distance(transform.position, currentTarget.position);
        if (currenDistance > range) return false;
        return true;
    }
    protected virtual bool CheckAlive()
    {
        if (currentTarget == null) return false;
        EnemyBaseCtrl enemyBaseCtrl = currentTarget.parent.GetComponent<EnemyBaseCtrl>();
        if (!enemyBaseCtrl.IsAlive) return false;
        return true;
    }
    protected virtual void FindEnemyInRange()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        if (hits.Length == 0 || hits == null)
        {
            if (line != null) line.enabled = false;
            currentTarget = null;
            return;
        }
        float targetDistance = 99f;
        float newDistance = 0f;
        foreach (Collider2D hit in hits)
        {
            newDistance = Vector3.Distance(transform.position, hit.transform.position);
            if (newDistance < targetDistance)
            {
                targetDistance = newDistance;
                currentTarget = hit.transform;
            }
        }
        if (line != null) line.enabled = true;

    }
    private void OnDrawGizmosSelected()
    {
        // Vẽ phạm vi range để debug
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
