using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLightSlashSmall : AbilityLightSlash
{
    protected override void Start()
    {
        base.Start();
        nameSkill = "LightSlashSmall";
    }
}
