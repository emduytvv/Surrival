using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPause : BaseBtn
{
    protected override void OnClick()
    {
        CenterCtrl.Instance.PauseSetting.gameObject.SetActive(true);
        GameManager.Instance.SetState(GameState.Pause);
    }
}
