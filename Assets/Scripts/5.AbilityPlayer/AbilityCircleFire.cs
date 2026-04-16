using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircleFire : AbilityLightning
{
    protected override void Start()
    {
        base.Start();
        this.nameSkill = "CircleFire";
    }
}
