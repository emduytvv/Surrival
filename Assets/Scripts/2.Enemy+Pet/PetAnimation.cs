using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimation : SaiMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected PetCtrl petCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadPetCtrl();

    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.GetComponent<PetCtrl>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }

    private void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator()", gameObject);
    }
    // Không cần SetMoving() vì luôn Walk
    //Gọi ở PetCombat
    public virtual void PlayAttack()
    {
        animator.SetTrigger("attack");
    }

    // public virtual void PlayHurt()
    // {
    //     animator.SetTrigger("isHurt");
    // }

    // public virtual void PlayDead()
    // {
    //     animator.SetTrigger("isDead");
    // }
    public virtual void CallDespawn()
    {
        petCtrl.Despawn.DespawnObject();
    }
    public virtual void CallSend()
    {
        PetCtrlCombat combatCtrl = petCtrl as PetCtrlCombat;
        if (combatCtrl == null) return;
        if (combatCtrl.PetCombat == null) return;
        combatCtrl.PetCombat.Send();
    }
}
