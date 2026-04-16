using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BtnSkillDamage2 : BaseBtn
{

    [SerializeField] private Transform indicator; // vòng tròn preview
    [SerializeField] protected AbilityCircleFire abilityCircleFire;
    [SerializeField] protected AbilityLightningSmall abilityLightningSmall;
    [SerializeField] protected AbilityLightningBig abilityLightningBig;
    [SerializeField] protected string nameSkill = "LightningBig";
    public void SetNameSkill(string nameSkill) => this.nameSkill = nameSkill;
    private void Update()
    {
        CheckTargeting();
    }
    protected override void Start()
    {
        base.Start();
        LoadAbility();
    }

    private void LoadAbility()
    {
        abilityCircleFire = ObjectReference.Instance.Player.GetComponentInChildren<AbilityCircleFire>();
        abilityLightningSmall = ObjectReference.Instance.Player.GetComponentInChildren<AbilityLightningSmall>();
        abilityLightningBig = ObjectReference.Instance.Player.GetComponentInChildren<AbilityLightningBig>();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadIndicator();
    }
    private void LoadIndicator()
    {
        indicator = transform.parent.parent.Find("CircleTarget");
        indicator.gameObject.SetActive(false);
    }
    public void SetIdSkill(string nameSkill)
    {
        this.nameSkill = nameSkill;
    }
    protected override void OnClick()
    {
        BeginTargeting();
    }

    [SerializeField] protected bool isTargeting;

    public void BeginTargeting()
    {
        isTargeting = true;
        indicator.gameObject.SetActive(true);
    }
    private void CheckTargeting()
    {
        if (!isTargeting) return;

        Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMouse.z = 0f;
        indicator.position = posMouse;

        if (!InputManager.Instance.LeftMouse) return;

        OnPickPosition(posMouse);
        indicator.gameObject.SetActive(false);
        isTargeting = false;
    }
    protected void OnPickPosition(Vector3 pos)
    {
        switch (nameSkill)
        {
            case "CircleFire":
                abilityCircleFire.SetMousePos(pos);
                abilityCircleFire.SetActivated(true);
                break;
            case "LightningSmall":
                abilityLightningSmall.SetMousePos(pos);
                abilityLightningSmall.SetActivated(true);
                break;
            case "LightningBig":
                abilityLightningBig.SetMousePos(pos);
                abilityLightningBig.SetActivated(true);
                break;
        }
    }
}
