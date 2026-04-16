
using UnityEngine;
public abstract class BaseWave : SaiMonoBehaviour
{
    [SerializeField] protected WaveDataSO waveData;
    public WaveDataSO WaveData => waveData;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyDataSO();
    }
    private void LoadEnemyDataSO()
    {
        if (this.waveData != null) return;
        string resPath = "WaveData/" + transform.name;
        this.waveData = Resources.Load<WaveDataSO>(resPath);
    }
    protected bool CanSpawn(EnemySpawnData data)
    {
        data.timer += Time.deltaTime;
        if (data.timer < data.timeSpawn) return false;
        data.timer = 0f;
        return true;
    }
    public abstract void Execute();
}