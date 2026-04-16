using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLevelPlayer : BaseText
{
    [SerializeField] protected float currentLevel;
    public void SetLevel(float currentLevel)
    {
        this.currentLevel = currentLevel;
    }
    protected override void ShowText()
    {
        textMeshProUGUI.text = "Lv." + currentLevel.ToString();
    }
}
