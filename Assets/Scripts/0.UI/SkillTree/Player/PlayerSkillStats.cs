using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkillStats : BaseSkillStats
{
    [SerializeField] protected AbilityPlayerProfileSO abilityPlayerProfileSO;
    public AbilityPlayerProfileSO AbilityPlayerProfileSO => abilityPlayerProfileSO;
    public string mana;
    public override string Mana => mana;
    public int cost;
    public override int Cost => cost;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadimageSkill();
        LoadNameSkill();
        LoadAbilityProfileSO();
        LoadSkillStats();
    }
    protected virtual void LoadNameSkill()
    {
        string name = transform.name;
        switch (name)
        {
            case "Skill0":
                nameSkill = "LightSlashSmall";
                break;
            case "Skill1":
                nameSkill = "LightSlashMedium";
                break;
            case "Skill2":
                nameSkill = "LightSlashBig";
                break;
            case "Skill3":
                nameSkill = "CircleFire";
                break;
            case "Skill4":
                nameSkill = "LightningSmall";
                break;
            case "Skill5":
                nameSkill = "LightningBig";
                break;
            case "Skill6":
                nameSkill = "BoostSpeed";
                break;
            case "Skill7":
                nameSkill = "BoostSpeed";
                break;
            case "Skill8":
                nameSkill = "BoostSpeed";
                break;
            case "Skill9":
                nameSkill = "BoostSpeed";
                break;
        }
    }
    private void LoadSkillStats()
    {
        typeSkill = abilityPlayerProfileSO.typeSkill;
        mana = abilityPlayerProfileSO.manaRequired.ToString();
        cooldown = abilityPlayerProfileSO.coolDown.ToString();
        damage = abilityPlayerProfileSO.damage.ToString();
        description = abilityPlayerProfileSO.description;
        cost = abilityPlayerProfileSO.cost;
        levelRequire = abilityPlayerProfileSO.levelRequire;
        requiredSkillId = abilityPlayerProfileSO.requiredSkillIds;
    }
    private void LoadimageSkill()
    {
        if (imageSkill != null) return;
        imageSkill = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadimageSkill()", gameObject);
    }
    private void LoadAbilityProfileSO()
    {
        if (this.abilityPlayerProfileSO != null) return;
        string resPath = "AbilityPlayerProfile/" + nameSkill;
        this.abilityPlayerProfileSO = Resources.Load<AbilityPlayerProfileSO>(resPath);
    }

}