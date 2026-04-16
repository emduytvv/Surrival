using System;
using UnityEngine;

[Serializable]
public enum EnemyTarget
{
    Player = 1,
    MainHome = 2,

}
public class NameEnemyTargetToString
{
    public static EnemyTarget ToString(string itemName)
    {
        return (EnemyTarget)System.Enum.Parse(typeof(EnemyTarget), itemName);
    }
}