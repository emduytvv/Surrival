using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnByPoint
{
    [Header("Enemy Spawner")]
    [SerializeField] private List<EnemySpawnData> enemys = new List<EnemySpawnData>();
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    protected Transform player;
    protected Transform mainHome;
    private BaseWave currentWave;
    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }
    protected override void ResetValue()
    {
        maxObject = 1000;
    }
    protected override void Start()
    {
        base.Start();
        player = ObjectReference.Instance.Player.transform;
        mainHome = ObjectReference.Instance.MainHome.transform;
    }
    protected override void SpawnRandom()
    {
        base.SpawnRandom();
    }
    public void SpawnByWave(string name, EnemyTarget nameTarget)
    {
        SpawnByPos(name, nameTarget, GetPointsRandom().position);
    }

    public void SpawnByPos(string name, EnemyTarget nameTarget, Vector3 pos)
    {
        if (CheckMaxObject()) return;
        CallFX(pos);

        Transform obj = SpawnByName(name, pos, Quaternion.identity);
        if (obj == null) return;

        SetAlive(obj);
        SetTarget(obj, nameTarget);
    }

    private void CallFX(Vector3 pos)
    {
        FXSpawner.Instance.SpawnOnCalled(FXName.Summon.ToString(), pos);
    }
    private void SetAlive(Transform obj)
    {
        obj.GetComponent<EnemyCtrl>()?.SetisAlive(true);
    }
    private void SetTarget(Transform obj, EnemyTarget nameTarget)
    {
        obj.GetComponentInChildren<MovementToTarget>()?.SetTarget(GetTargetByName(nameTarget));
        obj.GetComponentInChildren<ObjectLookAtTarget>()?.SetTarget(GetTargetByName(nameTarget));
    }
    public bool CheckMaxObject()
    {
        if (currentObject >= maxObject)
        {
            Debug.Log("Enemy Max Object");
        }
        return currentObject >= maxObject;
    }
    private Transform GetTargetByName(EnemyTarget nameTarget)
    {
        switch (nameTarget)
        {
            case EnemyTarget.Player:
                return player;
            case EnemyTarget.MainHome:
                return mainHome;
            default:
                return null;
        }
    }

}
