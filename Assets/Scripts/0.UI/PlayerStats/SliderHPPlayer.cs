using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHPPlayer : BaseSlider
{
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP = 10f;
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    [SerializeField] protected TextHPPlayer textHPPlayer;
    public TextHPPlayer TextHPPlayer => textHPPlayer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextHPPlayer();
    }
    private void LoadTextHPPlayer()
    {
        if (textHPPlayer != null) return;
        textHPPlayer = GetComponentInChildren<TextHPPlayer>();
        Debug.LogWarning(transform.name + ": LoadTextHPPlayer()", gameObject);
    }
    protected override void Start()
    {
        LoadPlayerDamageReceiver();
    }
    private void LoadPlayerDamageReceiver()
    {
        playerDamageReceiver = ObjectReference.Instance.Player.transform.GetComponentInChildren<PlayerDamageReceiver>();
    }
    void Update()
    {
        GetHP();
        TransmitHPToText();
        ShowHP();
    }

    private void TransmitHPToText()
    {
        TextHPPlayer.SetHP(currentHP, maxHP);
    }

    private void GetHP()
    {
        maxHP = playerDamageReceiver.maxHP;
        currentHP = playerDamageReceiver.currentHp;
    }

    private void ShowHP()
    {
        float rate = currentHP / maxHP;
        slider.value = rate;
    }

    // protected override void OnValueChange(float value)
    // {
    // }
}
