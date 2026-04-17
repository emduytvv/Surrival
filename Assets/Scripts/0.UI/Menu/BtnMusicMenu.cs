using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMusicMenu : BaseBtn
{
    protected override void OnClick()
    {
        OpenMusicSetting();
        CloseParents();
    }

    private void CloseParents()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void OpenMusicSetting()
    {
        CenterMenu.Instance.MusicSetting.gameObject.SetActive(true);
    }
}
