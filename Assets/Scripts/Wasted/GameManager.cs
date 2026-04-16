using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Play,
    Pause,
    GameOver
}

public class GameManager : SaiMonoBehaviour
{
    public static GameManager Instance => instance;
    protected static GameManager instance;

    public GameState State => state;
    private GameState state;
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
        }
    }
}
