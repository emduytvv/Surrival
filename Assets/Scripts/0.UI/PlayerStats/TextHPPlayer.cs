using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHPPlayer : BaseText
{
    [SerializeField] protected float currentHP;
    [SerializeField] protected float maxHP;
    public void SetHP(float currentHP, float maxHP)
    {
        this.currentHP = currentHP;
        this.maxHP = maxHP;
    }

    protected override void ShowText()
    {
        textMeshProUGUI.text = currentHP.ToString() + "/" + maxHP.ToString();
    }
}
