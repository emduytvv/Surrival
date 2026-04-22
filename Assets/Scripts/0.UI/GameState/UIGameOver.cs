using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : SaiMonoBehaviour, IGameOverObserver
{
    protected override void Start() => GameOverManager.Instance.Register(this);
    private void OnDisable() => GameOverManager.Instance.Unregister(this);

    public void GameOver()
    {
        transform.Find("UIGameOver").gameObject.SetActive(true);
    }
}
