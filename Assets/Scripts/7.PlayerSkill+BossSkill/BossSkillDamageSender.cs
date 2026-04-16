using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillDamageSender : DamageSender
{
    [SerializeField] protected BossSkillCtrl bossSkillCtrl;
    public BossSkillCtrl BossSkillCtrl => bossSkillCtrl;
    [SerializeField] protected int maxHits;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBossSkillCtrl();
    }

    private void LoadBossSkillCtrl()
    {
        if (bossSkillCtrl != null) return;
        bossSkillCtrl = transform.parent.GetComponent<BossSkillCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossSkillCtrl()", gameObject);
    }

    public override void Send()
    {
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver receiver = collision.GetComponent<DamageReceiver>();
        if (receiver == null) return;
        receiver.Receiver(damage);

        if (maxHits > 0)
        {
            maxHits--;
            return;
        }

        bossSkillCtrl.Despawn.DespawnObject();
    }
}
