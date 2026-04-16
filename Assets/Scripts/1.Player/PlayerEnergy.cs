using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : SaiMonoBehaviour
{

    [SerializeField] protected float baseEnergy = 200f;
    [SerializeField] protected float maxEnergy = 200f;
    public float MaxEnergy => maxEnergy;
    [SerializeField] protected float currentEnergy = 0;
    public float CurrentEnergy => currentEnergy;
    [SerializeField] protected float percentEnergy = 0f;
    [SerializeField] protected float maxenergyPerTime = 1f;
    [SerializeField] protected float energyPerTime = 0.5f;
    public float EnergyPerTime => energyPerTime;
    [SerializeField] protected float timeForAddEnergy = 1f;
    protected override void Start()
    {
        base.Start();
        SetMaxEnergy();
        InvokeRepeating(nameof(AddEnergyPerTime), timeForAddEnergy, timeForAddEnergy);
    }
    public void AddEnergy(float amount)
    {
        if (amount < 0) return;
        currentEnergy += amount;
        CheckMaxEnergy();
    }
    public void AddMaxEnergy(float amount)
    {
        if (amount < 0) return;
        baseEnergy += amount;
        SetMaxEnergy();
    }
    public void AddPercentEnergy(float percent)
    {
        percentEnergy += percent;
        SetMaxEnergy();
    }
    private void SetMaxEnergy()
    {
        maxEnergy = baseEnergy * (percentEnergy / 100 + 1);
    }
    protected virtual void CheckMaxEnergy()
    {
        if (currentEnergy > maxEnergy) { currentEnergy = maxEnergy; }
        if (currentEnergy < 0) { currentEnergy = 0; }
    }
    public bool TrySpendEnergy(float amount)
    {
        if (amount <= 0f) return false;
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            return true;
        }
        else { return false; }
    }
    protected virtual void AddEnergyPerTime()
    {
        currentEnergy += energyPerTime;
        CheckMaxEnergy();
    }
    public void UpdateEnergyPerTime(float amount)
    {
        if (amount <= 0f) return;
        energyPerTime += amount;
        if (energyPerTime > maxenergyPerTime) { energyPerTime = maxenergyPerTime; }
    }
}
