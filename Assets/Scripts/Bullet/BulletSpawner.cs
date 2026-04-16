
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("BulletSpawner")]
    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;
    protected string objectName = "BulletFollowEnemy";
    protected override void Reset()
    {
        base.Reset();
        maxObject = 100;
    }
    protected override void Awake()
    {
        base.Awake();
        BulletSpawner.instance = this;
    }
    public void SpawnBulletFollowTarget(Vector3 StartPoint, Transform target, string name, float damage)
    {
        Transform obj = SpawnByName(name, StartPoint, Quaternion.identity);
        obj.GetComponentInChildren<BulletMovementFollowTarget>().SetTarget(target);
        obj.GetComponentInChildren<BulletDamageSender>().SetDamage(damage);
    }
    public void SpawnBulletByDirection(Vector3 StartPoint, string name, Vector3 direction, float damage)
    {
        Transform obj = SpawnByName(name, StartPoint, Quaternion.identity);
        obj.GetComponentInChildren<MovementByDirection>().SetDirection(direction);
        obj.GetComponentInChildren<ObjectLookByDirection>().SetDirection(direction);
        obj.GetComponentInChildren<BulletDamageSender>().SetDamage(damage);
    }
}
