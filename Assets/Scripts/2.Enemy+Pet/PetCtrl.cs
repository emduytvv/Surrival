using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCtrl : ObjectCtrl
{
    public bool isAlive;
    public void SetisAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }
    [SerializeField] protected PetAnimation petAnimation;
    public PetAnimation PetAnimation => petAnimation;
    [SerializeField] protected PetDamageReceiver petDamageReceiver;
    public PetDamageReceiver PetDamageReceiver => petDamageReceiver;
    [SerializeField] protected ObjectLookAtTarget objectLookAtTarget;
    public ObjectLookAtTarget ObjectLookAtTarget => objectLookAtTarget;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetAnimation();
        LoadPetDamageReceiver();
        LoadObjectLookAtTarget();
        LoadPetDataSO();
    }
    [SerializeField] protected PetDataSO petDataSO;
    public PetDataSO PetDataSO => petDataSO;
    private void LoadPetDataSO()
    {
        if (this.petDataSO != null) return;
        string resPath = "PetData/" + transform.name;
        this.petDataSO = Resources.Load<PetDataSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadPetDataSO()", gameObject);
    }
    private void LoadObjectLookAtTarget()
    {
        if (objectLookAtTarget != null) return;
        objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjectLookAtTarget()", gameObject);
    }
    private void LoadPetAnimation()
    {
        if (petAnimation != null) return;
        petAnimation = GetComponentInChildren<PetAnimation>();
        Debug.LogWarning(transform.name + ": LoadPetAnimation()", gameObject);
    }
    private void LoadPetDamageReceiver()
    {
        if (petDamageReceiver != null) return;
        petDamageReceiver = GetComponentInChildren<PetDamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadPetDamageReceiver()", gameObject);
    }
}
