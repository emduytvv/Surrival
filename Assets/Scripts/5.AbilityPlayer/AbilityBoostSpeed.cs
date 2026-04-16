using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBoostSpeed : BaseAbilityPlayer
{
    [SerializeField] protected PlayerMovement playerMovement;
    [SerializeField] protected Transform speedTrail;
    [SerializeField] protected CooldownFillUI cooldownFillUI;
    protected override void Start()
    {
        base.Start();
        LoadCooldownFillUI();
    }

    private void LoadCooldownFillUI()
    {
        cooldownFillUI = ButtomRightCtrl.Instance.BtnSkillBuff1.GetComponentInChildren<CooldownFillUI>();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerMovement();
        LoadSpeedTrail();
    }
    private void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = transform.parent.parent.GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlayerMovement()", gameObject);
    }
    private void LoadSpeedTrail()
    {
        if (speedTrail != null) return;
        speedTrail = transform.Find("SpeedTrail");
        Debug.LogWarning(transform.name + ": LoadSpeedTrail()", gameObject);
    }
    protected override void Skill()
    {
        cooldownFillUI.Active(coolDown);
        playerMovement.BaseBuffTempSpeed(abilityPlayerProfileSO.percentSpeed, abilityPlayerProfileSO.duration);
        SetSpeedTrail();
    }
    private void SetSpeedTrail()
    {
        speedTrail.gameObject.SetActive(true);
        Invoke("DisableSpeedTrail", abilityPlayerProfileSO.duration);
    }
    private void DisableSpeedTrail() => speedTrail.gameObject.SetActive(false);
}
