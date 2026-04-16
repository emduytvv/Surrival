using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillDamageSender : DamageSender
{
    [SerializeField] protected PlayerSkillCtrl playerSkillCtrl;
    public PlayerSkillCtrl PlayerSkillCtrl => playerSkillCtrl;
    [SerializeField] protected int maxHits;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerSkillCtrl();
    }

    private void LoadPlayerSkillCtrl()
    {
        if (playerSkillCtrl != null) return;
        playerSkillCtrl = transform.parent.GetComponent<PlayerSkillCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerSkillCtrl()", gameObject);
    }
    public override void Send()
    {
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.transform.name);
        DamageReceiver receiver = collision.GetComponent<DamageReceiver>();
        if (receiver == null) return;
        receiver.Receiver(damage);
        if (maxHits > 0)
        {
            maxHits--;
            return;
        }
        playerSkillCtrl.Despawn.DespawnObject();
    }
}
