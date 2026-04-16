using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected float damage = 1;
    // protected virtual void Update()
    // {
    //     if (!CanSend()) return;
    //     Send();
    // }
    // protected abstract bool CanSend();
    public abstract void Send();
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
