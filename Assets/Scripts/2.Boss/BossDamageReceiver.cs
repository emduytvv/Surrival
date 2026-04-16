using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : DamageReceiver
{
    [SerializeField] protected BossCtrl bossCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBossCtrl();

    }
    private void LoadBossCtrl()
    {
        if (bossCtrl != null) return;
        bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl()", gameObject);
    }
    protected override void OnDead()
    {
        bossCtrl.SetisAlive(false);
        bossCtrl.BossAnimation.PlayDead();
    }
    protected override void Reduce(float damage)
    {
        currentHp -= damage;
        CheckHp();
        if (IsDead()) return;
        bossCtrl.BossAnimation.PlayHurt();
    }
}
