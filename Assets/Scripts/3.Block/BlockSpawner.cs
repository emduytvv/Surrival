
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : SpawnByPoint
{
    [Header("Block Spawner")]
    protected static BlockSpawner instance;
    public static BlockSpawner Instance => instance;
    protected string objectName = "Block_1";
    bool isSpawnFirst = true;
    protected override void Reset()
    {
        base.Reset();
        timeSpawn = 60f;
    }
    protected override void Awake()
    {
        base.Awake();
        BlockSpawner.instance = this;
    }
    protected override void Update()
    {
        if (isSpawnFirst)
        {
            SpawnFirst();
        }
        SpawnRandom();
    }
    protected virtual void SpawnFirst()
    {
        for (int i = 0; i < 10; i++)
        {
            Spawn();
        }
        isSpawnFirst = false;
    }
    protected override void Spawn()
    {
        currentPoint = GetPointsRandom();
        if (currentPoint == null) return;

        SpawnByName(objectName, currentPoint.position, Quaternion.identity);
    }
}
