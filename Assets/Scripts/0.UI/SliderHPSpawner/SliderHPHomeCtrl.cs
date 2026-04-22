using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHPHomeCtrl : BaseSlider
{
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP = 10f;
    [SerializeField] protected Transform target;
    public Transform Target => target;
    void Update()
    {
        GetHP();
        ShowHP();
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        GetComponentInChildren<SliderHpDespawn>()?.SetTarget(target);
        GetComponentInChildren<SliderHpMovement>()?.SetTarget(target);
    }
    protected virtual void GetHP()
    {
        if (target == null) return;
        maxHP = target.GetComponentInChildren<DamageReceiver>().maxHP;
        currentHP = target.GetComponentInChildren<DamageReceiver>().currentHp;
    }
    private void ShowHP()
    {
        float rate = currentHP / maxHP;
        slider.value = rate;
    }
}
