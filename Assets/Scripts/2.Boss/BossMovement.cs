using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MovementToTarget
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float minDistance = 1f;
    [SerializeField] protected float currentDistance;
    public float CurrentDistance => currentDistance;
    [SerializeField] protected Vector2 direction;
    public Vector2 Direction => direction;
    [SerializeField] protected BossCtrl bossCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody2D();
        LoadBossCtrl();
    }
    protected virtual void OnEnable()
    {
        moveSpeed = 1f;
    }
    private void LoadBossCtrl()
    {
        if (bossCtrl != null) return;
        bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl()", gameObject);
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
        if (bossCtrl.BossDamageReceiver.isDead) { rb.velocity = Vector2.zero; return; }
        if (!target) return;

        currentDistance = Vector3.Distance(transform.position, target.position);
        direction = target.position - transform.position;
        direction.Normalize();

        if (currentDistance <= minDistance) { rb.velocity = Vector2.zero; return; }
        rb.velocity = direction * moveSpeed;
    }
}
