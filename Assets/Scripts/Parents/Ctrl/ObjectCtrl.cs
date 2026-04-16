using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDespawn();
        // LoadStatsSO();
    }
    private void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": LoadDespawn()", gameObject);
    }
    // [SerializeField] protected StatsSO statsSO;
    // public StatsSO StatsSO => statsSO;

    // private void LoadStatsSO()
    // {
    //     if (this.statsSO != null) return;
    //     string resPath = "Stats/" + transform.name;
    //     this.statsSO = Resources.Load<StatsSO>(resPath);
    // }

}
