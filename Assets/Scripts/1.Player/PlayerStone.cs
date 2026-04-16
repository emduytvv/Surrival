using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStone : SaiMonoBehaviour
{
    [SerializeField] protected int maxStone = 100000;
    [SerializeField] protected int currentStone = 0;
    public int CurrentStone => currentStone;
    public void AddStone(int amount)
    {
        if (amount < 0) return;
        if (currentStone > maxStone - amount) return;

        currentStone += amount;
        CheckMaxStone();
    }

    protected virtual void CheckMaxStone()
    {
        if (currentStone > maxStone) { currentStone = maxStone; }
        if (currentStone < 0) { currentStone = 0; }
    }

    public bool TrySpendStone(int amount)
    {
        if (currentStone >= amount)
        {
            currentStone -= amount;
            return true;
        }
        else { return false; }
    }

}
