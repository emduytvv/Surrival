using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkillDamage1 : BaseBtn
{
    [SerializeField] protected AbilityLightSlashSmall abilityLightSlashSmall;
    [SerializeField] protected AbilityLightSlashMedium abilityLightSlashMedium;
    [SerializeField] protected AbilityLightSlashBig AbilityLightSlashBig;
    [SerializeField] protected string nameSkill = "LightSlashBig";
    public void SetNameSkill(string nameSkill) => this.nameSkill = nameSkill;
    protected override void Start()
    {
        base.Start();
        LoadAbility();

    }
    private void LoadAbility()
    {
        abilityLightSlashMedium = ObjectReference.Instance.Player.GetComponentInChildren<AbilityLightSlashMedium>();
        abilityLightSlashSmall = ObjectReference.Instance.Player.GetComponentInChildren<AbilityLightSlashSmall>();
        AbilityLightSlashBig = ObjectReference.Instance.Player.GetComponentInChildren<AbilityLightSlashBig>();
    }
    protected override void OnClick()
    {
        switch (nameSkill)
        {
            case "LightSlashSmall":
                abilityLightSlashSmall.SetActivated(true);
                break;
            case "LightSlashMedium":
                abilityLightSlashMedium.SetActivated(true);
                break;
            case "LightSlashBig":
                AbilityLightSlashBig.SetActivated(true);
                break;
        }
    }

}
