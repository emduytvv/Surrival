
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class SpawnByPoint : Spawner
{

    [SerializeField] protected float timer = 1;
    [SerializeField] protected float timeSpawn = 2f;
    [SerializeField] protected List<Transform> listPoints;
    protected Transform currentPoint;

    [SerializeField] protected Points points;
    public Points Points => points;
    protected virtual void Update()
    {
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoints();
    }
    private void LoadPoints()
    {
        if (points != null) return;
        points = GetComponentInChildren<Points>();
        Debug.LogWarning(transform.name + ": LoadPoint()", gameObject);
    }
    protected void FixedUpdate()
    {
        this.listPoints = points.ListPoints;
    }
    protected virtual void SpawnRandom()
    {
        timer += Time.deltaTime;
        if (timer < timeSpawn) return;
        timer = 0;
        currentPoint = GetPointsRandom();
        Spawn();
    }
    protected virtual Transform GetPointsRandom()
    {
        int index = Random.Range(0, listPoints.Count);
        return listPoints[index];
    }
    protected virtual void Spawn()
    {

    }
}

