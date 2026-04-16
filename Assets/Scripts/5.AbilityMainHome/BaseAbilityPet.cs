using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbilityPet : BaseAbility
{
    public void Update()
    {
        CheckIsReady();
        if (isReady)
        {
            ActivateSkill();
        }
    }
    protected virtual void CheckIsReady()
    {
        //Check Time
        timer += Time.deltaTime;
        if (timer < coolDown) return;
        this.isReady = true;

    }
    protected virtual void ActivateSkill()
    {
        Skill();
        Active();
    }
    protected abstract void Skill();
}
