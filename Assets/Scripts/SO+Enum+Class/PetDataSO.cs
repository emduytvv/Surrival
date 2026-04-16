using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PetDataSO")]
public class PetDataSO : ScriptableObject
{
    public float maxHP = 0;
    public int damage = 0;
    public float walkSpeed = 0f;
    public float runSpeed = 0f;
    public float coolDown = 0f;
    public float minDistance = 0f;
    public float distanceForAttack = 0;
    public float attackRange = 0;

}
