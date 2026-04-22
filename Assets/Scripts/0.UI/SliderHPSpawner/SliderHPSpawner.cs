using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderHPSpawner : Spawner
{
    [Header("SliderHPSpawner")]
    protected static SliderHPSpawner instance;
    public static SliderHPSpawner Instance => instance;
    protected Transform mainHome;
    protected List<Transform> enemyHomes;
    protected override void Reset()
    {
        base.Reset();
        maxObject = 100;
    }
    protected override void Awake()
    {
        base.Awake();
        SliderHPSpawner.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        LoadMainHome();
        LoadEnemyHome();

        SpawnHpMainHome();
        SpawnHpEnemyHome();
    }
    private void LoadEnemyHome()
    {
        enemyHomes = EnemyHomeManager.Instance.EnemyHomes;
    }
    private void LoadMainHome()
    {
        mainHome = ObjectReference.Instance.MainHome.transform;
    }
    public virtual void SpawnHpMainHome()
    {
        Transform obj = SpawnByName("SliderHPHome", Vector3.zero, Quaternion.identity);
        SetTarget(obj, mainHome);
    }
    public virtual void SpawnHpEnemyHome()
    {
        for (int i = 0; i < enemyHomes.Count; i++)
        {
            Transform obj = SpawnByName("SliderHPHome", Vector3.zero, Quaternion.identity);
            SetTarget(obj, enemyHomes[i]);
        }
    }
    private void SetTarget(Transform obj, Transform target)
    {
        obj.GetComponent<SliderHPHomeCtrl>()?.SetTarget(target);
    }
}
