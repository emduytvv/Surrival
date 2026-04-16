using UnityEngine;
public enum SpawnType { Enemy, Boss }
[System.Serializable]
public class EnemySpawnData
{
    public NameEnemy nameEnemy;
    public float timeSpawn = 2f;
    public float timer;
    public EnemyTarget target;
    public SpawnType spawnType;
}