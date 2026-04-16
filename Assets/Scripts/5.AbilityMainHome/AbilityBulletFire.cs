using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBulletFire : BaseAbilityMainHome
{
    protected override void Skill()
    {
        int count = 12;
        float step = 360f / count;

        Vector3 pos = transform.position;
        pos.y += 3f;

        for (int i = 0; i < count; i++)
        {
            float angle = i * step;
            float rad = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f).normalized;
            BulletSpawner.Instance.SpawnBulletByDirection(pos, "BulletFire", direction, damage);
        }
    }
}
