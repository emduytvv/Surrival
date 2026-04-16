using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkillTreeManager : SaiMonoBehaviour
{
    public List<BaseSkillStats> BaseSkillStats;
    [SerializeField] protected List<BaseBtnSkillStats> BaseBtnSkillStats;
    public List<BaseSkillUnlock> BaseSkillUnlock;
    public int currentSkillId;
    public virtual BaseSkillStats GetSkillStats()
    {
        return BaseSkillStats[currentSkillId];
    }
    public virtual BaseSkillStats GetSkillStatsById(int id)
    {
        return BaseSkillStats[id];
    }
    public virtual BaseBtnSkillStats GetBtnSkillStats()
    {
        return BaseBtnSkillStats[currentSkillId];
    }
    public virtual BaseSkillUnlock GetSkillUnlock()
    {
        return BaseSkillUnlock[currentSkillId];
    }
    public virtual BaseSkillUnlock GetSkillUnlockById(int id)
    {
        return BaseSkillUnlock[id];
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkill();
    }
    protected void LoadSkill()
    {
        if (BaseSkillStats.Count > 0) return;
        BaseSkillStats Skill;
        Transform leftPanel = transform.Find("LeftPanel");
        foreach (Transform skill in leftPanel)
        {

            if (Skill = skill.GetComponent<BaseSkillStats>())
            {
                BaseSkillStats.Add(Skill);
                BaseBtnSkillStats.Add(skill.GetComponent<BaseBtnSkillStats>());
                BaseSkillUnlock.Add(skill.GetComponent<BaseSkillUnlock>());
            }
        }
    }
}
