using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public float coolDown = 0f;
    public int damage = 0;
    public float minDistance = 0f;
    public float moveSpeed = 0f;
    public float maxHP = 0;
    public float distanceForAttack = 0;
    public float attackRange = 0;
    public EnemyTarget target = EnemyTarget.Player;

}
