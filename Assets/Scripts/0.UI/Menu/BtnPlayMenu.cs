using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlayMenu : BaseBtn
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
        CenterMenu.Instance.MapSelect.gameObject.SetActive(true);
    }
}
