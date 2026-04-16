using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbilityBoss : BaseAbility
{
    [Header("BaseAbilityBoss")]
    // [SerializeField] protected AbilityMainHomeProfileSO abilityMainHomeProfileSO;
    [SerializeField] protected bool activated = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        // LoadAbilityProfileSO();
        // LoadStatsSkill();

    }
    // protected virtual void LoadStatsSkill()
    // {
    //     // coolDown = abilityMainHomeProfileSO.coolDown;
    //     // damage = abilityMainHomeProfileSO.damage;
    //     timer = coolDown;
    // }

    // private void LoadAbilityProfileSO()
    // {
    //     if (this.abilityMainHomeProfileSO != null) return;
    //     string resPath = "AbilityMainHomeProfile/" + transform.name;
    //     this.abilityMainHomeProfileSO = Resources.Load<AbilityMainHomeProfileSO>(resPath);
    // }
    public void SetActivated()
    {
        activated = true;
    }
    protected virtual void Update()
    {
        // CheckIsReady();
        if (activated)
        {
            ActivateSkill();
        }
    }
    // protected virtual void CheckIsReady()
    // {
    //     //Check Time
    //     timer += Time.deltaTime;
    //     if (timer < coolDown) return;
    //     this.isReady = true;
    // }
    protected virtual void ActivateSkill()
    {
        Skill();
        Active();
    }
    protected override void Active()
    {
        base.Active();
        activated = false;
    }
    // public virtual void SetActivated(bool activated) => this.activated = activated;
    public abstract void Skill();
}
