using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDamageReceiver : DamageReceiver
{

    [SerializeField] protected Animator animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
    }

    private void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator()", gameObject);
    }

    protected override void OnDead()
    {
        animator.SetTrigger("isDead");
    }
    protected override void Reduce(float damage)
    {
        currentHp -= damage;
        CheckHp();
        if (IsDead()) return;
        animator.SetTrigger("attacked");
    }
    //ở animation break
    public void DeadOnAnimationEnd()
    {
        objectCtrl.Despawn.DespawnObject();
    }
    //ở animation break
    private void DropItemOnAnimationEnd()
    {
        BlockCtrl blockCtrl = transform.parent.GetComponent<BlockCtrl>();
        List<DropTable> dropTable = blockCtrl.ObjectDropData.DropTable;
        ItemSpawner.Instance.SpawnOnCalled(dropTable, transform);
    }
}
