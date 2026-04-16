using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public int damage = 0;
    public float moveSpeed = 0f;
    public float maxHP = 0;
    public float maxEnergy = 0;
    public int maxGold = 0;
    public int maxStone = 0;
    public int maxBook = 0;
    public int maxLevel = 0;

}
