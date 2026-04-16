using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAbstract : SaiMonoBehaviour
{
    [SerializeField] protected ObjectCtrl objectCtrl;
    public ObjectCtrl ObjectCtrl => objectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjectCtrl();
    }
    private void LoadObjectCtrl()
    {
        if (objectCtrl != null) return;
        objectCtrl = transform?.parent?.GetComponent<ObjectCtrl>();
    }

}
