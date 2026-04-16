using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLightningSmall : AbilityLightning
{
    protected override void Start()
    {
        base.Start();
        this.nameSkill = "LightningSmall";
    }
}

