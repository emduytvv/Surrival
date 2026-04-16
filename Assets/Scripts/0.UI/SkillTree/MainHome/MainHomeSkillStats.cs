using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MainHomeSkillStats : BaseSkillStats
{
    public int requiredBook;
    public override int RequiredBook => requiredBook;
    public int requiredStone;
    public override int RequiredStone => requiredStone;
    [SerializeField] protected AbilityMainHomeProfileSO abilityMainHomeProfileSO;
    public AbilityMainHomeProfileSO AbilityMainHomeProfileSO => abilityMainHomeProfileSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadNameSkill();
        LoadimageSkill();
        LoadAbilityProfileSO();
        LoadSkillStats();
    }
    protected virtual void LoadNameSkill()
    {
        string name = transform.name;
        switch (name)
        {
            case "Skill0":
                nameSkill = "BulletFire";
                break;
            case "Skill1":
                nameSkill = "BulletIce";
                break;
            case "Skill2":
                nameSkill = "BulletLight";
                break;
            case "Skill3":
                nameSkill = "BulletWind";
                break;
            case "Skill4":
                nameSkill = "BulletEarth";
                break;
            case "Skill5":
                nameSkill = "Dog";
                break;
            case "Skill6":
                nameSkill = "Bird";
                break;
            case "Skill7":
                nameSkill = "Bear";
                break;
            case "Skill8":
                nameSkill = "Angel";
                break;
        }
    }
    private void LoadSkillStats()
    {
        typeSkill = abilityMainHomeProfileSO.typeSkill;
        cooldown = abilityMainHomeProfileSO.coolDown.ToString();
        damage = abilityMainHomeProfileSO.damage.ToString();
        description = abilityMainHomeProfileSO.description;
        requiredBook = abilityMainHomeProfileSO.requiredBook;
        requiredStone = abilityMainHomeProfileSO.requiredStone;
        levelRequire = abilityMainHomeProfileSO.levelRequire;
        requiredSkillId = abilityMainHomeProfileSO.requiredSkillIds;
    }
    private void LoadimageSkill()
    {
        if (imageSkill != null) return;
        imageSkill = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadimageSkill()", gameObject);
    }
    private void LoadAbilityProfileSO()
    {
        if (this.abilityMainHomeProfileSO != null) return;
        string resPath = "AbilityMainHomeProfile/" + nameSkill;
        this.abilityMainHomeProfileSO = Resources.Load<AbilityMainHomeProfileSO>(resPath);
    }

}