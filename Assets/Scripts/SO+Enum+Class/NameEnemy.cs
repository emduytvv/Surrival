using System;
using UnityEngine;

[Serializable]
public enum NameEnemy
{
    SlimeCarrot = 1,
    SlimeGreen = 2,
    BatBlack = 3,
    BatBrown = 4,
    BatPink = 5,
    BatPurple = 6,
    BatOrange = 7,
    GolemBlue = 8,
    GolemStone = 9,
}
public class NameEnemyToString
{
    public static NameEnemy ToString(string itemName)
    {
        return (NameEnemy)System.Enum.Parse(typeof(NameEnemy), itemName);
    }
}