using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbilityBoss
{
    [SerializeField] protected List<Transform> points = new List<Transform>();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoints();
    }

    private void LoadPoints()
    {
        if (points.Count > 0) return;
        foreach (Transform point in transform)
        {
            points.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadPoints()", gameObject);
    }

    public override void Skill()
    {
        foreach (Transform point in points)
        {
            EnemySpawner.Instance.SpawnByPos(NameEnemy.SlimeGreen.ToString(), EnemyTarget.Player, point.position);
        }
    }
}
