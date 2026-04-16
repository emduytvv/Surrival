using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : BaseWave
{
    public override void Execute()
    {
        for (int i = 0; i < waveData.listEnemySpawnData.Count; i++)
        {
            EnemySpawnData data = waveData.listEnemySpawnData[i];
            if (!CanSpawn(data)) continue;

            string name = data.nameEnemy.ToString();

            if (data.spawnType == SpawnType.Enemy)
                EnemySpawner.Instance.SpawnByWave(name, data.target);
            else if (data.spawnType == SpawnType.Boss)
                BossSpawner.Instance.SpawnByWave(name, data.target);
        }
    }
}
