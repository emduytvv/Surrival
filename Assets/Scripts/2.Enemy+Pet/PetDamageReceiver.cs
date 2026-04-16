using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetDamageReceiver : DamageReceiver
{
    [SerializeField] protected PetCtrl petCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetCtrl();
        LoadMaxHP();
    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.GetComponent<PetCtrl>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }
    private void LoadMaxHP()
    {
        maxHP = petCtrl.PetDataSO.maxHP;
    }
    protected override void OnDead()
    {
        // petCtrl.PetAnimation.PlayDead();
    }
    protected override void Reduce(float damage)
    {
        currentHp -= damage;
        CheckHp();
        if (IsDead()) return;
        // petCtrl.PetAnimation.PlayHurt();
    }
}
