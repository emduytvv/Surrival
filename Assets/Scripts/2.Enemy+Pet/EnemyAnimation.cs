using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : SaiMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadEnemyCtrl();

    }
    private void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl()", gameObject);
    }

    private void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator()", gameObject);
    }
    // Không cần SetMoving() vì luôn Walk
    public virtual void PlayAttack()
    {
        animator.SetTrigger("attack");
    }

    public virtual void PlayHurt()
    {
        animator.SetTrigger("isHurt");
    }

    public virtual void PlayDead()
    {
        // animator.SetBool("isDead", true);
        animator.ResetTrigger("isHurt");
        animator.ResetTrigger("attack");
        animator.SetTrigger("isDead");
        // animator.ResetTrigger("isDead");


    }
    public virtual void CallDespawn()
    {
        enemyCtrl.Despawn.DespawnObject();
    }
    public virtual void CallSend()
    {
        enemyCtrl.EnemyCombat.Send();
    }
}
