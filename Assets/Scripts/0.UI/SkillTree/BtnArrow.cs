using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnArrow : BaseBtn
{
    protected override void OnClick()
    {
        CenterCtrl.Instance.SkillTreeManager.gameObject.SetActive(true);
    }
}
