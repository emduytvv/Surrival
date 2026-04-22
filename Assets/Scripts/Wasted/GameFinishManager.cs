using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameFinishManager : SaiMonoBehaviour
{
    public static GameFinishManager Instance => instance;
    protected static GameFinishManager instance;
    private List<IGameFinishObserver> observers = new List<IGameFinishObserver>();

    public void Register(IGameFinishObserver o) => observers.Add(o);
    public void Unregister(IGameFinishObserver o) => observers.Remove(o);
    protected override void Awake()
    {
        instance = this;
    }
    public void OnGameFinish()
    {
        SetUnlockMap();
        AddHistory();
        TriggerGameFinish();
    }
    public void TriggerGameFinish()
    {
        foreach (var o in observers)
            o.GameFinish();
    }
    private void SetUnlockMap()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
    }
    private void AddHistory()
    {
        BattleHistoryManager.Instance.AddRecord(
        SceneManager.GetActiveScene().name,
        GameTimer.Instance.Minutes,
        GameTimer.Instance.Seconds,
        isWin: true
        );
    }
}
