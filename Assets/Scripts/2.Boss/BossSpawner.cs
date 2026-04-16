using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : SpawnByPoint
{
    [Header("BossSpawner")]
    [SerializeField] private List<EnemySpawnData> boss = new List<EnemySpawnData>();
    protected static BossSpawner instance;
    public static BossSpawner Instance => instance;
    protected Transform player;
    protected Transform mainHome;

    protected override void Awake()
    {
        base.Awake();
        BossSpawner.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        player = ObjectReference.Instance.Player.transform;
        mainHome = ObjectReference.Instance.MainHome.transform;
    }
    protected override void ResetValue()
    {
        maxObject = 1;
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
        obj.GetComponent<BossCtrl>()?.SetisAlive(true);
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
            Debug.Log("Boss Max Object");
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
    // protected void LoadDataBoss()
    // {
    //     boss = new List<EnemySpawnData>()
    //     {
    //         new EnemySpawnData { objectName = "GolemStone", timeSpawn = 5f, timer = 0f, target=ObjectReference.Instance.Player.transform},
    //     };

    // }
    // protected override void SpawnRandom()
    // {
    //     float dt = Time.deltaTime;

    //     foreach (var b in boss)
    //     {
    //         b.timer += dt;
    //         if (b.timer < b.timeSpawn) continue;
    //         b.timer = 0f;

    //         if (currentObject >= maxObject) continue;

    //         currentPoint = GetPointsRandom();
    //         if (currentPoint == null) continue;

    //         Transform obj = SpawnByName(b.objectName, currentPoint.position, Quaternion.identity);
    //         if (obj == null) continue;

    //         BossCtrl bossCtrl = obj.GetComponent<BossCtrl>();
    //         if (bossCtrl != null) bossCtrl.SetisAlive(true);

    //         obj.GetComponentInChildren<MovementToTarget>().SetTarget(b.target);
    //         obj.GetComponentInChildren<ObjectLookAtTarget>().SetTarget(b.target);
    //     }
    // }

}
