using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRestoreManaPlayer : BaseText
{
    [SerializeField] protected float manaPerTime;
    public void SetManaPerTime(float manaPerTime)
    {
        this.manaPerTime = manaPerTime;

    }
    protected override void ShowText()
    {
        textMeshProUGUI.text = manaPerTime.ToString() + "/s";
    }
}
