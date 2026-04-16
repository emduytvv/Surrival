using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLightning : BaseAbilityPlayer
{
    protected string nameSkill = "LightningSmall";
    protected Vector3 mousePos;
    [SerializeField] protected CooldownFillUI cooldownFillUI;
    protected override void Start()
    {
        base.Start();
        LoadCooldownFillUI();
    }

    private void LoadCooldownFillUI()
    {
        cooldownFillUI = ButtomRightCtrl.Instance.BtnSkillDamage2.GetComponentInChildren<CooldownFillUI>();
    }
    public void SetMousePos(Vector3 pos)
    {
        this.mousePos = pos;
    }
    protected override void Skill()
    {
        //Set cooldown UI
        cooldownFillUI.Active(coolDown);

        PlayerSkillSpawner.Instance.SpawnSkill2Click(mousePos, nameSkill);
    }
}
