using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseParentAndOpenMenu : BaseBtn
{
    protected override void OnClick()
    {
        OpenMenu();
        CloseParent();
    }

    private void CloseParent()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void OpenMenu()
    {
        CenterMenu.Instance.Menu.gameObject.SetActive(true);
    }
}
