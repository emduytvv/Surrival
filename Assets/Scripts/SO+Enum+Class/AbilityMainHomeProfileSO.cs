using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AbilityMainHomeProfileSO")]
public class AbilityMainHomeProfileSO : ScriptableObject
{
    public Sprite icon;
    public string typeSkill;
    public string description;
    public string nameSkill;
    public float coolDown = 0f;
    public float damage = 0f;
    public int levelRequire = 0;
    public int requiredStone = 0;
    public int requiredBook = 0;
    public int[] requiredSkillIds;
}
