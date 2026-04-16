using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHomeFindAndDrawLine : FindAndDrawLine
{
    [SerializeField] protected MainHomeCtrl mainHomeCtrl;
    public MainHomeCtrl MainHomeCtrl => mainHomeCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainHomeCtrl();
    }
    protected override void LoadLayerMaskName()
    {
        LayerMaskName = "Enemy";
    }
    private void LoadMainHomeCtrl()
    {
        if (mainHomeCtrl != null) return;
        mainHomeCtrl = transform.parent.GetComponent<MainHomeCtrl>();
        Debug.LogWarning(transform.name + ": LoadMainHomeCtrl()", gameObject);
    }

    protected override void Attack()
    {
        MainHomeCtrl.MainHomeShootingEnemy.Fire(currentTarget);
    }
}
