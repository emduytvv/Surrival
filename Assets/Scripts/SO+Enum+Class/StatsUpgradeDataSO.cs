using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/StatsUpgradeDataSO")]
public class StatsUpgradeDataSO : ScriptableObject
{
    public float upgradeMaxHP = 0;
    public float upgradeMaxMana = 0f;
    public float upgradeSpeed = 0f;
    public float upgradeAttack = 0f;
    public int donateGold = 0;
    public int donateBook = 0;
    public int donateStone = 0;
    public int upgradePercentHP = 0;
    public int upgradePercentMana = 0;
    public float upgradeDamage = 0;
    public int upgradePercentDamage = 0;
    public int upgradePercentSpeed = 0;

    public string description = "";
    public Sprite sprite = null;
}
