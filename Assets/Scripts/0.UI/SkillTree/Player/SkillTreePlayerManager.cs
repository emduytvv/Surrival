using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreePlayerManager : BaseSkillTreeManager
{
    protected static SkillTreePlayerManager instance;
    public static SkillTreePlayerManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        SkillTreePlayerManager.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkill();
    }
}
