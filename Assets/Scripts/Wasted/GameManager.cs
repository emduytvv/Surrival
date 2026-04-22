using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Play,
    Pause,
    GameOver,
    GameFinish
}

public class GameManager : SaiMonoBehaviour, IGameOverObserver, IGameFinishObserver
{
    public static GameManager Instance => instance;
    protected static GameManager instance;

    public GameState State => state;
    private GameState state;
    protected override void Start()
    {
        GameOverManager.Instance.Register(this);
        GameFinishManager.Instance.Register(this);
    }
    private void OnDisable()
    {
        GameOverManager.Instance.Unregister(this);
        GameFinishManager.Instance.Unregister(this);
    }
    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
    public void GameFinish()
    {
        SetState(GameState.GameFinish);
    }
    protected override void Awake()
    {
        instance = this;
    }
    public void SetState(GameState newState)
    {
        state = newState;

        switch (State)
        {
            case GameState.Play:
                Time.timeScale = 1f;
                break;

            case GameState.Pause:
                Time.timeScale = 0f;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                break;
            case GameState.GameFinish:
                Time.timeScale = 0f;
                break;
        }
    }
}
