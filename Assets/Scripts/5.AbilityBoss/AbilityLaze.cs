using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLaze : BaseAbilityBoss
{
    [SerializeField] protected BossCtrl bossCtrl;
    [SerializeField] protected Transform pointLaze;
    [SerializeField] protected Transform lazePrefab;
    [SerializeField] protected Vector2 direction;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBossCtrl();
        LoadPointLaze();
    }

    private void LoadPointLaze()
    {
        if (pointLaze != null) return;
        pointLaze = transform.Find("PointLaze");
        Debug.LogWarning(transform.name + ": LoadPointLaze()", gameObject);
    }

    private void LoadBossCtrl()
    {
        if (bossCtrl != null) return;
        bossCtrl = transform.parent.parent.GetComponent<BossCtrl>();
        Debug.LogWarning(transform.name + ": LoadBossCtrl()", gameObject);
    }
    protected override void Update()
    {
        base.Update();
        CallDespawnLaze();
    }
    //Call ở Animation
    public override void Skill()
    {
        Quaternion quaternion = Quaternion.Euler(0f, 0f, 0f);
        direction = bossCtrl.BossMovement.Direction;
        if (direction.x < 0)
        {
            quaternion = Quaternion.Euler(0f, 0f, 180f);
        }
        lazePrefab = BossSkillSpawner.Instance.SpawnOnCalled(pointLaze.position, "Laze", quaternion);
    }
    private void CallDespawnLaze()
    {
        if (GetIsAlive() || lazePrefab == null) return;
        lazePrefab.GetComponentInChildren<Despawn>().DespawnObject();
    }
    private bool GetIsAlive()
    {
        return bossCtrl.IsAlive;
    }
}
