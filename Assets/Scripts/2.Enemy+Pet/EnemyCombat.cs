using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : DamageSender
{
    // [SerializeField] protected float range = 3f;
    [SerializeField] protected float attackRange = 0.5f;
    [SerializeField] protected float distanceForAttack = 0.6f;
    // [SerializeField] protected float SpeedAttack = 0.5f;
    private Transform Point;
    [SerializeField] private Transform rightPoint;
    [SerializeField] protected LayerMask ObjectLayers;
    // [SerializeField] protected EnemyCtrl enemyCtrl;
    protected float currentDistance;
    protected Vector2 direction;
    protected float timer = 0f;
    protected float coolDown = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLayerMask();
        LoadPoint();
        LoadEnemyCtrl();
        LoadEnemyData();

    }

    private void LoadEnemyData()
    {
        damage = enemyCtrl.EnemyData.damage;
        coolDown = enemyCtrl.EnemyData.coolDown;
        distanceForAttack = enemyCtrl.EnemyData.distanceForAttack;
        attackRange = enemyCtrl.EnemyData.attackRange;
    }

    [SerializeField] protected EnemyCtrl enemyCtrl;
    private void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl()", gameObject);
    }
    private void LoadPoint()
    {
        rightPoint = transform.Find("RightPoint");
    }
    private void LoadLayerMask()
    {
        ObjectLayers = LayerMask.GetMask("Player", "MainHome");
    }
    protected virtual void Update()
    {
        GetDistance();
        GetPoint();
        Attack();
    }

    private void Attack()
    {
        if (!CanAttack()) return;
        CallAnimationAttack();
    }

    private void CallAnimationAttack()
    {
        enemyCtrl.EnemyAnimation.PlayAttack();
    }

    private bool CanAttack()
    {
        timer += Time.deltaTime;
        if (timer < coolDown) return false;
        timer = 0f;

        if (currentDistance <= distanceForAttack) return true;
        return false;
    }

    private void GetDistance()
    {
        this.currentDistance = enemyCtrl.EnemyMovement.CurrentDistance;
    }

    private void GetPoint()
    {
        Point = rightPoint;
    }
    //Call ở animation attack
    public override void Send()
    {
        Collider2D[] Targets = Physics2D.OverlapCircleAll(Point.position, attackRange, ObjectLayers);
        foreach (Collider2D target in Targets)
        {
            DamageReceiver receiver = target.GetComponent<DamageReceiver>();
            if (receiver == null) continue;
            receiver.Receiver(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (Point == null) return;
        Gizmos.DrawWireSphere(Point.position, attackRange);
    }
}
