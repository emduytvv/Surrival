using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossSkillSpawner : Spawner
{
    [Header("BossSkillSpawner")]
    protected static BossSkillSpawner instance;
    public static BossSkillSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        BossSkillSpawner.instance = this;
    }

    public Transform SpawnOnCalled(Vector3 startPoint, string name, Quaternion quaternion)
    {
        Transform obj = SpawnByName(name, startPoint, quaternion);
        float zAngle = quaternion.eulerAngles.z;
        // Debug.Log(zAngle);
        return obj;
    }
}
