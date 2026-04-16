
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBulletLight : BaseAbilityMainHome
{
    protected override void Skill()
    {
        int count = 5;
        Vector3 pos = transform.position;
        pos.y += 3f;

        for (int i = 0; i < count; i++)
        {
            float angle = Random.Range(0f, 360f);
            float rad = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f).normalized;
            BulletSpawner.Instance.SpawnBulletByDirection(pos, "BulletLight", direction, damage);
        }
    }
}
