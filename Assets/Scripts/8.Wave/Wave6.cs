using System.Collections.Generic;
using UnityEngine;

public class Wave6 : BaseWave
{
    public override void Execute()
    {
        for (int i = 0; i < waveData.listEnemySpawnData.Count; i++)
        {
            if (!CanSpawn(waveData.listEnemySpawnData[i])) continue;
            EnemySpawner.Instance.SpawnByWave(waveData.listEnemySpawnData[i].nameEnemy.ToString(), waveData.listEnemySpawnData[i].target);
        }
    }
}
