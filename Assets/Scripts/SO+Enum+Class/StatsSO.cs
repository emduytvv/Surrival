using UnityEngine;

[CreateAssetMenu(menuName = "SO/StatsSO")]
public class StatsSO : ScriptableObject
{
    [Header("Health")]
    public float maxHP = 10;

    [Header("MoveSpeed")]
    public float moveSpeed = 3f;
}
