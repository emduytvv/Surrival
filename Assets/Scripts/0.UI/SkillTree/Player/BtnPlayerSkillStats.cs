using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BtnPlayerSkillStats : BaseBtnSkillStats
{
    [SerializeField] public Transform textCost;
    public override Transform TextCost => textCost;
    [SerializeField] protected TextMeshProUGUI mana;
    [SerializeField] protected TextMeshProUGUI cost;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMana();
        LoadTextCost();
        LoadCost();
    }
    private void LoadCost()
    {
        if (cost != null) return;
        cost = transform.parent.parent
            .Find("RightPanel")
            .Find("BtnUnlock")
            .Find("Cost")
            .GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadCost()", gameObject);
    }
    private void LoadMana()
    {
        if (mana != null) return;
        mana = transform.parent.parent
            .Find("RightPanel")
            .Find("Mana")
            .GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadMana()", gameObject);
    }
    private void LoadTextCost()
    {
        if (textCost != null) return;
        textCost = transform.parent.parent
            .Find("RightPanel")
            .Find("BtnUnlock")
            .Find("Cost");
        Debug.LogWarning(transform.name + " : LoadTextCost()", gameObject);
    }
    protected override void OnClick()
    {
        base.OnClick();
        SkillTreePlayerManager.Instance.currentSkillId = skillId;

        mana.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].Mana;
        imageSkill.sprite = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].imageSkill.sprite;
        nameSkill.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].nameSkill;
        description.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].description;
        typeSkill.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].typeSkill;
        damage.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].damage;
        cooldown.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].cooldown;
        cost.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].Cost.ToString();
        levelRequire.text = SkillTreePlayerManager.Instance.BaseSkillStats[skillId].levelRequire.ToString();

        SkillTreePlayerManager.Instance.BaseSkillUnlock[skillId].SetTextUnlock();
    }
}
