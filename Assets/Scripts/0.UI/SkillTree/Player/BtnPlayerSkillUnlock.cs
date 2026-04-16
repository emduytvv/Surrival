using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlayerSkillUnlock : BaseBtn
{
    protected override void OnClick()
    {
        SkillTreePlayerManager.Instance.GetSkillUnlock().CheckUnlock();
    }
}
