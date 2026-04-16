using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTimeGame : BaseText
{
    protected override void ShowText()
    {
        textMeshProUGUI.text = GameTimer.Instance.GetTimeFormatted();
    }
}
