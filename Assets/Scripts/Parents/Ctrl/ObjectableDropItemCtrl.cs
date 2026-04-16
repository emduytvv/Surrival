using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectableDropItemCtrl : ObjectCtrl
{
    [SerializeField] protected ObjectDropDataSO objectDropData;
    public ObjectDropDataSO ObjectDropData => objectDropData;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyDataSO();
    }
    private void LoadEnemyDataSO()
    {
        if (this.objectDropData != null) return;
        string resPath = "ObjectDropData/" + transform.name;
        this.objectDropData = Resources.Load<ObjectDropDataSO>(resPath);
    }
}
