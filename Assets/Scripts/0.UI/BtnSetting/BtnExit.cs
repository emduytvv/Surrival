using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnExit : BaseBtn
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
