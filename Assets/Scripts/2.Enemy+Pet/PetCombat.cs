using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCombat : DamageSender
{
    [SerializeField] protected float attackRange = 0.5f;
    [SerializeField] protected float distanceForAttack = 1f;
    // [SerializeField] protected float SpeedAttack = 0.5f;
    private Transform Point;
    [SerializeField] private Transform rightPoint;
    [SerializeField] protected PetCtrlCombat petCtrl;
    protected float currentDistance;
    [SerializeField] protected LayerMask ObjectLayers;
    protected Vector2 direction;
    protected float timer = 0f;
    [SerializeField] protected float coolDown = 0.5f;
    [SerializeField] protected bool foundTarget = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoint();
        LoadLayerMask();
        LoadPetCtrl();
        LoadPetData();
    }
    private void LoadPetData()
    {
        damage = petCtrl.PetDataSO.damage;
        coolDown = petCtrl.PetDataSO.coolDown;
        distanceForAttack = petCtrl.PetDataSO.distanceForAttack;
        attackRange = petCtrl.PetDataSO.attackRange;
    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.GetComponent<PetCtrlCombat>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }
    private void LoadLayerMask()
    {
        ObjectLayers = LayerMask.GetMask("Enemy");
    }
    private void LoadPoint()
    {
        rightPoint = transform.Find("RightPoint");
    }
    protected virtual void Update()
    {
        GetDistance();
        GetPoint();
        Attack();
    }
    private void CallAnimationAttack()
    {
        petCtrl.PetAnimation.PlayAttack();
    }
    public void SetFoundTarget(bool value)
    {
        this.foundTarget = value;
    }
    private void Attack()
    {
        if (!foundTarget) return;
        if (!CanAttack()) return;
        CallAnimationAttack();
    }
    public bool CanAttack()
    {
        timer += Time.deltaTime;
        if (timer < coolDown) return false;
        timer = 0f;
        if (currentDistance <= distanceForAttack) return true;
        return false;
    }
    private void GetDistance()
    {
        this.currentDistance = petCtrl.PetMovement.CurrentDistance;
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
