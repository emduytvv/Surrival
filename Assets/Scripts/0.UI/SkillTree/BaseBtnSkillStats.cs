using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public abstract class BaseBtnSkillStats : BaseBtn
{
    [SerializeField] protected Image imageSkill;
    [SerializeField] protected TextMeshProUGUI nameSkill;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected int skillId;
    [SerializeField] protected TextMeshProUGUI typeSkill;
    [SerializeField] protected TextMeshProUGUI damage;
    [SerializeField] protected TextMeshProUGUI cooldown;
    [SerializeField] public Transform textUnlock;
    [SerializeField] protected TextMeshProUGUI levelRequire;
    //Player
    public virtual Transform TextCost => null;
    //MainHome
    public virtual Transform TransformBook => null;
    public virtual Transform TransformStone => null;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDescription();
        LoadImageSkill();
        LoadNameSkill();
        LoadTypeSkill();
        LoadDamage();
        LoadCooldown();
        LoadSkillId();
        LoadTextUnlock();
        LoadLevelRequire();
    }
    private void LoadSkillId()
    {

        string objName = this.transform.name;
        string numberPart = objName.Replace("Skill", "", StringComparison.OrdinalIgnoreCase);

        if (int.TryParse(numberPart, out int id))
        {
            if (skillId == id) return;
            skillId = id;
            Debug.LogWarning($"{transform.name} : LoadSkillId()", gameObject);
            return;
        }
        Debug.LogError($"{transform.name} : Cannot parse skillId from name '{objName}'. Expected 'Skill<number>'.", gameObject);
    }
    private void LoadDescription()
    {
        if (description != null) return;
        description = transform.parent.parent.Find("RightPanel").Find("Description").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadDescription()", gameObject);
    }
    private void LoadImageSkill()
    {
        if (imageSkill != null) return;
        imageSkill = transform.parent.parent.Find("RightPanel").Find("ImageSkill").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImageSkill()", gameObject);
    }
    private void LoadNameSkill()
    {
        if (nameSkill != null) return;
        nameSkill = transform.parent.parent.Find("RightPanel").Find("NameSkill").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadNameSkill()", gameObject);
    }
    private void LoadTypeSkill()
    {
        if (typeSkill != null) return;

        typeSkill = transform.parent.parent
            .Find("RightPanel")
            .Find("TypeSkill")
            .GetComponent<TextMeshProUGUI>();

        Debug.LogWarning(transform.name + " : LoadTypeSkill()", gameObject);
    }
    private void LoadDamage()
    {
        if (damage != null) return;
        damage = transform.parent.parent
            .Find("RightPanel")
            .Find("Damage")
            .GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadDamage()", gameObject);
    }
    private void LoadCooldown()
    {
        if (cooldown != null) return;
        cooldown = transform.parent.parent
            .Find("RightPanel")
            .Find("Cooldown")
            .GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadCooldown()", gameObject);
    }
    private void LoadTextUnlock()
    {
        if (textUnlock != null) return;
        textUnlock = transform.parent.parent
            .Find("RightPanel")
            .Find("BtnUnlock")
            .Find("Unlock");
        Debug.LogWarning(transform.name + " : LoadTextUnlock()", gameObject);
    }
    private void LoadLevelRequire()
    {
        if (levelRequire != null) return;
        levelRequire = transform.parent.parent
            .Find("RightPanel")
            .Find("LevelRequire")
            .GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadLevelRequire()", gameObject);
    }
    protected override void OnClick() { }

}
