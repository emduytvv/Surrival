using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyBaseCtrl
{
    [SerializeField] protected BossCombat bossCombat;
    public BossCombat BossCombat => bossCombat;
    [SerializeField] protected BossAnimation bossAnimation;
    public BossAnimation BossAnimation => bossAnimation;
    [SerializeField] protected BossDamageReceiver bossDamageReceiver;
    public BossDamageReceiver BossDamageReceiver => bossDamageReceiver;
    [SerializeField] protected BossMovement bossMovement;
    public BossMovement BossMovement => bossMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBossCombat();
        LoadBossAnimation();
        LoadBossDamageReceiver();
        LoadBossMovement();
    }
    private void LoadBossCombat()
    {
        if (bossCombat != null) return;
        bossCombat = GetComponentInChildren<BossCombat>();
        Debug.LogWarning(transform.name + ": LoadBossCombat()", gameObject);
    }
    private void LoadBossMovement()
    {
        if (bossMovement != null) return;
        bossMovement = GetComponentInChildren<BossMovement>();
        Debug.LogWarning(transform.name + ": LoadBossMovement()", gameObject);
    }

    private void LoadBossAnimation()
    {
        if (bossAnimation != null) return;
        bossAnimation = GetComponentInChildren<BossAnimation>();
        Debug.LogWarning(transform.name + ": LoadBossAnimation()", gameObject);
    }
    private void LoadBossDamageReceiver()
    {
        if (bossDamageReceiver != null) return;
        bossDamageReceiver = GetComponentInChildren<BossDamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadBossDamageReceiver()", gameObject);
    }


}
