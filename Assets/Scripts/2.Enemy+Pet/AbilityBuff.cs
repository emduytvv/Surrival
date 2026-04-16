using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBuff : BaseAbilityPet
{
    [SerializeField] protected Transform target;
    [SerializeField] protected PetCtrl petCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetCtrl();

    }
    private void LoadPetCtrl()
    {
        if (petCtrl != null) return;
        petCtrl = transform.parent.parent.GetComponent<PetCtrl>();
        Debug.LogWarning(transform.name + ": LoadPetCtrl()", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        LoadPlayer();
    }
    protected virtual void LoadPlayer() => target = ObjectReference.Instance.Player.transform;

    protected override void Skill()
    {
        target.GetComponentInChildren<DamageReceiver>().Buff(damage);
    }
}

