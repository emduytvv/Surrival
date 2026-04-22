using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircleFind : SaiMonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    protected int pointCount = 360;
    protected float radius = 5f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLineRenderer();
    }

    private void LoadLineRenderer()
    {
        if (lineRenderer != null) return;
        lineRenderer = GetComponent<LineRenderer>();
        Debug.LogWarning(transform.name + ": LoadLineRenderer()", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        LoadRadius();
        DrawLineCircle();
    }

    private void LoadRadius()
    {
        radius = transform.parent.GetComponentInChildren<FindTargetObject>().Range;
    }

    protected void DrawLineCircle()
    {
        lineRenderer.positionCount = pointCount + 1;
        for (int i = 0; i <= pointCount; i++)
        {
            float angle = i * Mathf.PI * 2 / pointCount;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            lineRenderer.SetPosition(i, transform.position + new Vector3(x, y, 0));
        }
    }
}
