using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : SaiMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int maxLevel = 20;
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;
    [SerializeField] protected int expToNextLevel = 100;
    public int ExpToNextLevel => expToNextLevel;
    [Header("Exp")]
    [SerializeField] protected int currentExp = 0;
    public int CurrentExp => currentExp;
    [SerializeField] protected int expMaxUpdatePerLevel = 40;
    [SerializeField] protected int timeForAddExp = 10;
    [SerializeField] protected int ExpAddPerTime = 1;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(AddExpPerTime), timeForAddExp, timeForAddExp);
    }
    public void AddExp(int amount)
    {
        if (CheckMaxLevel()) return;
        if (amount < 0) return;
        currentExp += amount;
        CheckUpdateLevel();
    }
    protected virtual void CheckUpdateLevel()
    {
        if (currentExp < expToNextLevel) return;
        if (CheckMaxLevel()) return;
        currentLevel += 1;
        CenterCtrl.Instance.LevelUpStatsManager.GetComponent<LevelUpStatsManager>().OnLevelUp();

        currentExp -= expToNextLevel;
        expToNextLevel += expMaxUpdatePerLevel;
    }
    protected virtual bool CheckMaxLevel()
    {
        return currentLevel >= maxLevel;
    }

    protected virtual void AddExpPerTime()
    {
        AddExp(ExpAddPerTime);
    }
}
