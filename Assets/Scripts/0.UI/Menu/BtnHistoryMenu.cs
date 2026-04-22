using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnHistoryMenu : BaseBtn
{
    protected override void OnClick()
    {
        OpenMapSelect();
        CloseParents();
    }

    private void CloseParents()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void OpenMapSelect()
    {
        CenterMenu.Instance.History.gameObject.SetActive(true);
    }
}
