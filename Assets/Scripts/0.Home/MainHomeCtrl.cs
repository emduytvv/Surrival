using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHomeCtrl : ObjectCtrl
{
    [SerializeField] protected MainHomeShootingEnemy mainHomeShootingEnemy;
    public MainHomeShootingEnemy MainHomeShootingEnemy => mainHomeShootingEnemy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainHomeShootingEnemy();
    }
    private void LoadMainHomeShootingEnemy()
    {
        if (mainHomeShootingEnemy != null) return;
        mainHomeShootingEnemy = GetComponentInChildren<MainHomeShootingEnemy>();
        Debug.LogWarning(transform.name + ": MainHomeShootingEnemy()", gameObject);
    }
}
