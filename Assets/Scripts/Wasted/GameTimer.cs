using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : SaiMonoBehaviour
{
    protected static GameTimer instance;
    public static GameTimer Instance => instance;
    public float GameTime => gameTime;
    [SerializeField] private float gameTime = 0f;
    private int minutes = 0;
    public int Minutes => minutes;
    private int seconds = 0;
    public int Seconds => seconds;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    // Trả về dạng "01:30"
    public string GetTimeFormatted()
    {
        minutes = (int)(gameTime / 60);
        seconds = (int)(gameTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
