using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseCtrl : ObjectableDropItemCtrl
{
    [SerializeField] protected bool isAlive;
    public bool IsAlive => isAlive;
    public void SetisAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }
}
