using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHPMainHome : BaseSlider
{
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP = 10f;
    [SerializeField] protected MainHomeDamageReceiver mainHomeDamageReceiver;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void Start()
    {
        LoadPlayerDamageReceiver();
    }
    private void LoadPlayerDamageReceiver()
    {
        mainHomeDamageReceiver = ObjectReference.Instance.MainHome.transform.GetComponentInChildren<MainHomeDamageReceiver>();
    }
    void Update()
    {
        GetHP();
        ShowHP();
        SetPosition();
    }
    protected void SetPosition()
    {
        transform.position = mainHomeDamageReceiver.transform.position + Vector3.up * 3.5f;
    }
    private void GetHP()
    {
        maxHP = mainHomeDamageReceiver.maxHP;
        currentHP = mainHomeDamageReceiver.currentHp;
    }
    private void ShowHP()
    {
        float rate = currentHP / maxHP;
        slider.value = rate;
    }

}
