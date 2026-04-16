using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLightSlash : BaseAbilityPlayer
{
    [Header("AbilityLightSlash")]
    [SerializeField] Vector2 direction;
    [SerializeField] Quaternion quaternion;
    protected string nameSkill = "LightSlashMedium";
    [SerializeField] protected CooldownFillUI cooldownFillUI;
    protected override void Start()
    {
        base.Start();
        LoadCooldownFillUI();
    }

    private void LoadCooldownFillUI()
    {
        cooldownFillUI = ButtomRightCtrl.Instance.BtnSkillDamage1.GetComponentInChildren<CooldownFillUI>();
    }

    protected virtual void FixedUpdate()
    {
        GetDirectionAndQuaternion();

    }
    protected void GetDirectionAndQuaternion()
    {
        if (playerCtrl.PlayerMovement.Direction == Vector2.zero) return;

        direction = playerCtrl.PlayerMovement.Direction;
        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        quaternion = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected override void Skill()
    {
        //Set cooldown UI
        cooldownFillUI.Active(coolDown);

        PlayerSkillSpawner.Instance.SpawnSkill1Click(transform.position, nameSkill, direction, quaternion);
    }
}
