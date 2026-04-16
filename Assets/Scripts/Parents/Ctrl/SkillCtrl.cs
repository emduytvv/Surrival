using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : ObjectCtrl
{
    [SerializeField] protected AbilityPlayerProfileSO abilityPlayerProfileSO;
    public AbilityPlayerProfileSO AbilityPlayerProfileSO => abilityPlayerProfileSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilityProfileSO();
    }
    private void LoadAbilityProfileSO()
    {
        if (this.abilityPlayerProfileSO != null) return;
        string resPath = "AbilityPlayerProfile/" + transform.name;
        this.abilityPlayerProfileSO = Resources.Load<AbilityPlayerProfileSO>(resPath);
    }

}
