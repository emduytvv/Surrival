
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBulletEarth : BaseAbilityMainHome
{
    protected override void Skill()
    {
        StartCoroutine(Spawn12WithDelay());
    }
    private IEnumerator Spawn12WithDelay()
    {
        int count = 5;
        Vector3 pos = transform.position;
        pos.y += 3f;

        for (int i = 0; i < count; i++)
        {
            float angle = Random.Range(0f, 360f);
            float rad = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f).normalized;

            BulletSpawner.Instance.SpawnBulletByDirection(pos, "BulletEarth", direction, damage);

            yield return new WaitForSeconds(0.5f); // đợi rồi mới bắn viên tiếp theo
        }
    }
}
