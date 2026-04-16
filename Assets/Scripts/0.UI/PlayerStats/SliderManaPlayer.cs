using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManaPlayer : BaseSlider
{
    [SerializeField] protected float maxMana = 100f;
    [SerializeField] protected float currentMana = 10f;
    [SerializeField] protected float ManaPerTime = 1f;
    [SerializeField] protected PlayerEnergy playerEnergy;
    [SerializeField] protected TextManaPlayer textManaPlayer;
    [SerializeField] protected TextRestoreManaPlayer textRestoreManaPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextManaPlayer();
        LoadTextRestoreManaPlayer();
    }

    private void LoadTextManaPlayer()
    {
        if (textManaPlayer != null) return;
        textManaPlayer = GetComponentInChildren<TextManaPlayer>();
        Debug.LogWarning(transform.name + ": LoadTextManaPlayer()", gameObject);
    }
    private void LoadTextRestoreManaPlayer()
    {
        if (textRestoreManaPlayer != null) return;
        textRestoreManaPlayer = GetComponentInChildren<TextRestoreManaPlayer>();
        Debug.LogWarning(transform.name + ": LoadTextManaPlayer()", gameObject);
    }

    protected override void Start()
    {
        LoadPlayerEnergy();
    }
    private void LoadPlayerEnergy()
    {
        playerEnergy = ObjectReference.Instance.Player.transform.GetComponentInChildren<PlayerEnergy>();
    }
    void Update()
    {
        GetMana();
        TransmitManaToText();
        ShowMana();
    }

    private void TransmitManaToText()
    {
        textManaPlayer.SetMana(currentMana, maxMana);
        textRestoreManaPlayer.SetManaPerTime(ManaPerTime);
    }

    private void GetMana()
    {
        maxMana = playerEnergy.MaxEnergy;
        currentMana = playerEnergy.CurrentEnergy;
        ManaPerTime = playerEnergy.EnergyPerTime;
    }

    private void ShowMana()
    {
        float rate = currentMana / maxMana;
        slider.value = rate;
    }

    // protected override void OnValueChange(float value)
    // {
    // }
}
