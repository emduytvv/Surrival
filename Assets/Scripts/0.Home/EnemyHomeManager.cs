using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeManager : ObjectCtrl
{
    private static EnemyHomeManager instance;
    public static EnemyHomeManager Instance => instance;
    [SerializeField] private List<Transform> enemyHomes;
    public List<Transform> EnemyHomes => enemyHomes;
    private int EnemyHomeCount;
    protected override void Awake()
    {
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        EnemyHomeCount = enemyHomes.Count;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyHomes();
    }

    private void LoadEnemyHomes()
    {
        if (enemyHomes.Count > 0) return;
        foreach (Transform child in transform)
        {
            enemyHomes.Add(child);
        }
    }
    public void OnHomeDestroy()
    {
        EnemyHomeCount -= 1;
        CheckWin();
    }

    private void CheckWin()
    {
        if (EnemyHomeCount > 0) return;
        GameFinishManager.Instance.OnGameFinish();
    }
}
