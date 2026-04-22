using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTriggerTutorial : SaiMonoBehaviour
{
    [SerializeField] private List<Transform> points;
    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < points.Count; i++)
        {
            EnemySpawner.Instance.SpawnByPos(NameEnemy.BatOrange.ToString(), EnemyTarget.Player, points[i].position);
        }
        gameObject.SetActive(false);
    }
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
}
