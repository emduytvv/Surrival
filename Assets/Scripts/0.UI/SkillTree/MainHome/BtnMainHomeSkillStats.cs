using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BtnMainHomeSkillStats : BaseBtnSkillStats
{
    [SerializeField] public Transform transformBook;
    public override Transform TransformBook => transformBook;
    [SerializeField] protected TextMeshProUGUI book;
    [SerializeField] public Transform transformStone;
    public override Transform TransformStone => transformStone;
    [SerializeField] protected TextMeshProUGUI stone;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTransformBook();
        LoadBook();
        LoadTransformStone();
        LoadStone();
    }
    private void LoadBook()
    {
        if (book != null) return;
        book = transformBook.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadBook()", gameObject);
    }
    private void LoadTransformBook()
    {
        if (transformBook != null) return;
        transformBook = transform.parent.parent
            .Find("RightPanel")
            .Find("BtnUnlock")
            .Find("Book");
        Debug.LogWarning(transform.name + " : LoadTransformBook()", gameObject);
    }
    private void LoadStone()
    {
        if (stone != null) return;
        stone = transformStone.GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " : LoadBook()", gameObject);
    }
    private void LoadTransformStone()
    {
        if (transformStone != null) return;
        transformStone = transform.parent.parent
            .Find("RightPanel")
            .Find("BtnUnlock")
            .Find("Stone");
        Debug.LogWarning(transform.name + " : LoadTransformStone()", gameObject);
    }

    protected override void OnClick()
    {
        base.OnClick();
        SkillTreeMainHomeManager.Instance.currentSkillId = skillId;

        stone.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].RequiredStone.ToString();
        book.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].RequiredBook.ToString();
        imageSkill.sprite = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].imageSkill.sprite;
        nameSkill.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].nameSkill;
        description.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].description;
        typeSkill.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].typeSkill;
        damage.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].damage;
        cooldown.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].cooldown;
        levelRequire.text = SkillTreeMainHomeManager.Instance.BaseSkillStats[skillId].levelRequire.ToString();

        SkillTreeMainHomeManager.Instance.BaseSkillUnlock[skillId].SetTextUnlock();
    }
}
