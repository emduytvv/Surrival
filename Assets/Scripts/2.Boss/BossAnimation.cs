using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : SaiMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected BossCtrl bossCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadBossCtrl();
    }
    private void LoadBossCtrl()
    {
        if (bossCtrl != null) return;
        bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl()", gameObject);
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
        // animator.SetBool("isDeadBool", true);
        // animator.SetBool("isDead", true);
        animator.ResetTrigger("isHurt");
        animator.ResetTrigger("attack");
        animator.SetTrigger("isDead");
    }

    public virtual void PlayLaze()
    {
        animator.SetTrigger("isLaze");
    }
    public virtual void PlaySummon()
    {
        animator.SetTrigger("isSummon");
    }

    public virtual void CallAttack()
    {
        bossCtrl.BossCombat.Attack();
    }
    public virtual void CallDespawn()
    {
        bossCtrl.Despawn.DespawnObject();
    }
    public virtual void CallSend()
    {
        bossCtrl.BossCombat.Send();
    }
    public virtual void CallLaze()
    {
        bossCtrl.transform.Find("BossAbility").GetComponentInChildren<AbilityLaze>().SetActivated();
    }
}
