using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeMainHomeManager : BaseSkillTreeManager
{
    protected static SkillTreeMainHomeManager instance;
    public static SkillTreeMainHomeManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        SkillTreeMainHomeManager.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkill();
    }
}
