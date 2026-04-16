using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BaseSkillStats : SaiMonoBehaviour
{
    public Image imageSkill;
    public string nameSkill;
    public string typeSkill;
    public string description;
    public string damage;
    public string cooldown;
    public int levelRequire;
    public int[] requiredSkillId;
    //Player
    public virtual int Cost => -1;
    public virtual string Mana => string.Empty;
    //MainHome
    public virtual int RequiredBook => -1;
    public virtual int RequiredStone => -1;

}