using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbilityPlayer : BaseAbility
{
    [Header("AbilityPlayer")]
    [SerializeField] protected float manaRequired = 5f;
    [SerializeField] protected bool activated = false;

    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected PlayerEnergy playerEnergy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilityProfileSO();
        LoadStatsSkill();
        LoadPlayerCtrl();
        LoadPlayerEnergy();
    }
    [SerializeField] protected AbilityPlayerProfileSO abilityPlayerProfileSO;
    public AbilityPlayerProfileSO AbilityPlayerProfileSO => abilityPlayerProfileSO;

    protected virtual void LoadStatsSkill()
    {
        coolDown = abilityPlayerProfileSO.coolDown;
        damage = abilityPlayerProfileSO.damage;
        timer = coolDown;
        manaRequired = abilityPlayerProfileSO.manaRequired;
    }

    private void LoadAbilityProfileSO()
    {
        if (this.abilityPlayerProfileSO != null) return;
        string resPath = "AbilityPlayerProfile/" + transform.name;
        this.abilityPlayerProfileSO = Resources.Load<AbilityPlayerProfileSO>(resPath);
    }
    public void Update()
    {
        CheckIsReady();
        if (isReady)
        {
            ActivateSkill();
        }
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    private void LoadPlayerEnergy()
    {
        if (playerEnergy != null) return;
        playerEnergy = playerCtrl.GetComponentInChildren<PlayerEnergy>();
        Debug.LogWarning(transform.name + ": LoadPlayerEnergy()", gameObject);
    }
    public void SetActivated(bool value)
    {
        if (timer < coolDown) return;
        this.activated = value;
    }
    protected virtual void CheckIsReady()
    {
        //Check Time
        timer += Time.deltaTime;
        if (timer < coolDown) return;

        //Check activeted
        if (!activated) return;

        //Chheck Mana
        if (!playerEnergy.TrySpendEnergy(manaRequired))
        {
            Debug.Log("Mana not enough");
            activated = false;
            return;
        }
        this.isReady = true;

    }
    protected virtual void ActivateSkill()
    {
        Skill();
        Active();
        activated = false;
    }
    protected abstract void Skill();
}
