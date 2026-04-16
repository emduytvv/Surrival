using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSpeaker : BaseBtn
{
    protected override void OnClick()
    {
        CenterCtrl.Instance.MusicSetting.gameObject.SetActive(true);
    }
}
