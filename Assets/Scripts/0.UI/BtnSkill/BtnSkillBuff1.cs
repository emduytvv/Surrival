using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkillBuff1 : BaseBtn
{
    [SerializeField] protected AbilityBoostSpeed abilityBoostSpeed;
    protected override void Start()
    {
        base.Start();
        LoadAbility();
    }
    private void LoadAbility()
    {
        abilityBoostSpeed = ObjectReference.Instance.Player.GetComponentInChildren<AbilityBoostSpeed>();
    }
    protected override void OnClick()
    {
        abilityBoostSpeed.SetActivated(true);
    }

}
