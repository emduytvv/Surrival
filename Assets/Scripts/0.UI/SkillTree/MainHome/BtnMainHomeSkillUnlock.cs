using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMainHomeSkillUnlock : BaseBtn
{
    protected override void OnClick()
    {
        SkillTreeMainHomeManager.Instance.GetSkillUnlock().CheckUnlock();
    }
}
