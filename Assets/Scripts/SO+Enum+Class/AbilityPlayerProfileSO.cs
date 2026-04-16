using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AbilityPlayerProfileSO")]
public class AbilityPlayerProfileSO : ScriptableObject
{
    public Sprite icon;
    public string typeSkill;
    public string description;
    public string nameSkill;
    public float manaRequired = 0f;
    public float coolDown = 0f;
    public float damage = 0f;
    public int cost = 0;
    public int levelRequire = 0;
    public int[] requiredSkillIds;
    public int percentSpeed = 0;
    public float duration = 0f;
}
