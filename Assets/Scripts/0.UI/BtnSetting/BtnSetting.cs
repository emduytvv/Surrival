using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : BaseBtn
{
    [SerializeField] protected List<Transform> listTransform;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTransform();
    }

    private void LoadTransform()
    {
        if (listTransform.Count > 0) return;
        listTransform = new List<Transform>();
        foreach (Transform child in transform)
        {
            listTransform.Add(child);
            child.gameObject.SetActive(false);
        }
    }

    protected override void OnClick()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
