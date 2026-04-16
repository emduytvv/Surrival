using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManger : SaiMonoBehaviour
{
    private int minutes;
    [SerializeField] protected List<BaseWave> waves = new List<BaseWave>();
    private int lastMinutes = -1;
    private BaseWave currentWave;
    protected override void Start()
    {
        base.Start();
        // EnemySpawner.Instance.SetWave(waves[0]);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadWave();
    }
    private void LoadWave()
    {
        if (waves.Count > 0) return;
        foreach (Transform child in transform)
        {
            waves.Add(child.GetComponent<BaseWave>());
        }
    }
    protected void FixedUpdate()
    {
        GetTimer();
        SetWave();
        RunWave();
    }

    private void RunWave()
    {
        currentWave?.Execute();
    }

    private void GetTimer()
    {
        minutes = GameTimer.Instance.Minutes;
    }
    public void SetWave()
    {
        if (!CanNextWave()) return;
        lastMinutes = minutes;

        switch (minutes)
        {
            case 0: currentWave = waves[0]; Debug.Log("Start Spawn Wave 1"); break;
            case 2: currentWave = waves[1]; Debug.Log("Start Spawn Wave 2"); break;
            case 4: currentWave = waves[2]; Debug.Log("Start Spawn Wave 3"); break;
            case 6: currentWave = waves[3]; Debug.Log("Start Spawn Wave 4"); break;
            case 8: currentWave = waves[4]; Debug.Log("Start Spawn Wave 5"); break;
            case 10: currentWave = waves[5]; Debug.Log("Start Spawn Wave 6"); break;
            case 12: currentWave = waves[6]; Debug.Log("Start Spawn Wave 7"); break;
            case 14: currentWave = waves[7]; Debug.Log("Start Spawn Wave 8"); break;
            default: break;
        }
    }
    private bool CanNextWave()
    {
        return minutes > lastMinutes;
    }
}
