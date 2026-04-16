
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementByDirectionRandom : MovementByDirection
{
    [SerializeField] protected ObjectLookByDirection objectLookByDirection;
    public ObjectLookByDirection ObjectLookByDirection => objectLookByDirection;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjectLookAtTarget();
    }

    private void LoadObjectLookAtTarget()
    {
        if (objectLookByDirection != null) return;
        objectLookByDirection = transform.parent.GetComponentInChildren<ObjectLookByDirection>();
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(RandomDirection), 0.25f, 0.25f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(RandomDirection));
    }

    private void RandomDirection()
    {
        float angle = Random.Range(0f, 360f);
        float rad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f).normalized;
        SetDirection(direction);
        objectLookByDirection.SetDirection(direction);
    }

}
