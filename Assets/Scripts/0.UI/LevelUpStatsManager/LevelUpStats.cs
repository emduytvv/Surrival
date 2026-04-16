using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpStats : SaiMonoBehaviour
{
    [SerializeField] protected StatsUpgradeDataSO statsUpgradeDataSO;
    public StatsUpgradeDataSO StatsUpgradeDataSO => statsUpgradeDataSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilityProfileSO();
    }
    private void LoadAbilityProfileSO()
    {
        if (this.statsUpgradeDataSO != null) return;
        string resPath = "StatsUpgradeData/" + gameObject.transform.name;
        this.statsUpgradeDataSO = Resources.Load<StatsUpgradeDataSO>(resPath);
    }
}
