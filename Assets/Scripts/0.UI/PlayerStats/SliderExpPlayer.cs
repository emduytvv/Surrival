using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderExpPlayer : BaseSlider
{
    [SerializeField] protected float maxExp = 100f;
    [SerializeField] protected float currentExp = 10f;
    [SerializeField] protected float currentLevel = 1f;
    [SerializeField] protected PlayerExperience playerExperience;
    [SerializeField] protected TextLevelPlayer textLevelPlayer;
    public TextLevelPlayer TextLevelPlayer => textLevelPlayer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextLevelPlayer();
    }
    private void LoadTextLevelPlayer()
    {
        if (textLevelPlayer != null) return;
        textLevelPlayer = GetComponentInChildren<TextLevelPlayer>();
        Debug.LogWarning(transform.name + ": LoadTextLevelPlayer()", gameObject);
    }
    protected override void Start()
    {
        LoadPlayerExperience();
    }
    private void LoadPlayerExperience()
    {
        playerExperience = ObjectReference.Instance.Player.transform.GetComponentInChildren<PlayerExperience>();
    }
    void Update()
    {
        GetExp();
        TransmitLevelToText();
        ShowHP();
    }

    private void TransmitLevelToText()
    {
        textLevelPlayer.SetLevel(currentLevel);
    }

    private void GetExp()
    {
        maxExp = playerExperience.ExpToNextLevel;
        currentExp = playerExperience.CurrentExp;
        currentLevel = playerExperience.CurrentLevel;
    }

    private void ShowHP()
    {
        float rate = currentExp / maxExp;
        slider.value = rate;
    }

    // protected override void OnValueChange(float value)
    // {
    // }
}
