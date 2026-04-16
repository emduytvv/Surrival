using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovementToTarget
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float minDistance = 1f;
    [SerializeField] protected float currentDistance;
    public float CurrentDistance => currentDistance;
    protected Vector2 direction;
    public Vector2 Direction => direction;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
        LoadMoveSpeed();
        LoadRigidbody2D();

    }
    // protected override void Awake()
    // {
    //     base.Awake();
    // }
    private void LoadMoveSpeed()
    {
        this.moveSpeed = enemyCtrl.EnemyData.moveSpeed;
        this.minDistance = enemyCtrl.EnemyData.minDistance;
    }

    private void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    private void LoadRigidbody2D()
    {
        if (rb != null) return;
        rb = transform.parent.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        Debug.LogWarning(transform.name + ": LoadRigidbody2D()", gameObject);
    }


    protected override void Moving()
    {
        if (enemyCtrl.EnemyDamageReceiver.isDead) { rb.velocity = Vector2.zero; return; }
        if (!target) return;

        currentDistance = Vector3.Distance(transform.position, target.position);
        if (currentDistance <= minDistance) { rb.velocity = Vector2.zero; return; }

        direction = target.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
    }
}
