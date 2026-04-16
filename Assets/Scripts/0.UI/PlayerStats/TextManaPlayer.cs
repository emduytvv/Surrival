using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManaPlayer : BaseText
{
    [SerializeField] protected float currentMana;
    [SerializeField] protected float maxMana;
    public void SetMana(float currentMana, float maxMana)
    {
        this.currentMana = currentMana;
        this.maxMana = maxMana;
    }

    protected override void ShowText()
    {
        textMeshProUGUI.text = $"{currentMana:0.0}/{maxMana:0}";
    }
}
