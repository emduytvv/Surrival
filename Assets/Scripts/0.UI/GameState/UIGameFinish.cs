using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameFinish : SaiMonoBehaviour, IGameFinishObserver
{
    protected override void Start() => GameFinishManager.Instance.Register(this);
    private void OnDisable() => GameFinishManager.Instance.Unregister(this);

    public void GameFinish()
    {
        transform.Find("UIGameFinish").gameObject.SetActive(true);
    }
}
