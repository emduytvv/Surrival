using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPanelSelection : BaseBtn
{
    protected override void OnClick()
    {
        UpgradeOnClick();
    }
    private void UpgradeOnClick()
    {
        LevelUpStatsManager.Instance.UpgradeOnClick(name);
    }

}
