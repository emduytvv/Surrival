using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenSkillSystem : BaseBtn
{
    protected override void OnClick()
    {
        CenterCtrl.Instance.SkillTreeManager.gameObject.SetActive(true);
    }
}
