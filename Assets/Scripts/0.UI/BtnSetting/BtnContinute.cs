using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnContinute : BaseBtn
{
    protected override void OnClick()
    {
        GameManager.Instance.SetState(GameState.Play);
        transform.parent.parent.parent.gameObject.SetActive(false);
    }
}
