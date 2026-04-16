
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSkillSpawner : Spawner
{
    [Header("PlayerSkillSpawner")]
    protected static PlayerSkillSpawner instance;
    public static PlayerSkillSpawner Instance => instance;
    // protected string objectName1 = "LightSlash";
    protected override void Awake()
    {
        base.Awake();
        PlayerSkillSpawner.instance = this;
    }
    public void SpawnSkill1Click(Vector3 StartPoint, string name, Vector3 direction, Quaternion quaternion)
    {
        Transform obj = SpawnByName(name, StartPoint, quaternion);
        obj.GetComponentInChildren<MovementByDirection>().SetDirection(direction);
    }
    public void SpawnSkill2Click(Vector3 StartPoint, string name)
    {
        Transform obj = SpawnByName(name, StartPoint, Quaternion.identity);
    }
}
