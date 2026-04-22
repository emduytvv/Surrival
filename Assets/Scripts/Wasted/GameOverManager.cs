using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : SaiMonoBehaviour
{
    public static GameOverManager Instance => instance;
    protected static GameOverManager instance;
    private List<IGameOverObserver> observers = new List<IGameOverObserver>();

    public void Register(IGameOverObserver o) => observers.Add(o);
    public void Unregister(IGameOverObserver o) => observers.Remove(o);
    public void TriggerGameOver()
    {
        foreach (var o in observers)
            o.GameOver();
    }
    protected override void Awake()
    {
        instance = this;
    }
    public void OnGameOver()
    {
        AddHistory();
        TriggerGameOver();
    }
    private void AddHistory()
    {
        BattleHistoryManager.Instance.AddRecord(
        SceneManager.GetActiveScene().name,
        GameTimer.Instance.Minutes,
        GameTimer.Instance.Seconds,
        isWin: false
        );
    }

}
