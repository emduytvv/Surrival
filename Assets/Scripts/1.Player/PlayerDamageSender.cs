using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [SerializeField] protected float baseDamage = 1;

    [SerializeField] private Transform upPoint;
    [SerializeField] private Transform downPoint;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    private bool PressLeftMouse;
    private Transform Point;
    private Vector2 direction;
    protected float attackRange = 0.3f;
    protected LayerMask enemyLayers;
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected PlayerCtrl PlayerCtrl => playerCtrl;
    private float percentDamage = 0;
    protected override void Start()
    {
        base.Start();
        SetTotalDamage();
        Point = downPoint;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
        LoadLayerMask();
        LoadPoint();
    }
    private void LoadPoint()
    {
        upPoint = transform.Find("UpPoint");
        downPoint = transform.Find("DownPoint");
        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    private void LoadLayerMask()
    {
        enemyLayers = LayerMask.GetMask("Enemy", "Block");
    }
    protected void Update()
    {
        GetInPut();
        GetPoint();
    }
    private void GetPoint()
    {
        if (direction.y > 0)
        {
            Point = upPoint;
        }
        else if (direction.y < 0)
        {
            Point = downPoint;
        }
        else if (direction.x > 0)
        {
            Point = rightPoint;
        }
        else if (direction.x < 0)
        {
            Point = leftPoint;
        }
    }
    private void GetInPut()
    {
        PressLeftMouse = InputManager.Instance.LeftMouse;
        this.direction = PlayerCtrl.PlayerMovement.Direction;
    }
    public override void Send()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Point.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            DamageReceiver receiver = enemy.GetComponent<DamageReceiver>();
            receiver.Receiver(damage);
            CameraMovement.Instance.Shake();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (Point == null) return;
        Gizmos.DrawWireSphere(Point.position, attackRange);
    }
    public virtual void AddPercentDamage(float percent)
    {
        percentDamage += percent;
        SetTotalDamage();
    }
    public virtual void AddDamage(float amount)
    {
        baseDamage += amount;
        SetTotalDamage();
    }
    private void SetTotalDamage()
    {
        damage = baseDamage * (percentDamage / 100 + 1);
    }
}
