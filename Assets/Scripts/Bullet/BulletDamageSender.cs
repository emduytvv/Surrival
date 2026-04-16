using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }
    private void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl()", gameObject);
    }
    public override void Send()
    {
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver receiver = collision.GetComponent<DamageReceiver>();
        if (receiver == null) return;
        receiver.Receiver(damage);
        GetFX(collision.ClosestPoint(transform.position));
        BulletCtrl.Despawn.DespawnObject();
    }

    private void GetFX(Vector3 position)
    {
        string name = transform.parent.name;
        switch (name)
        {
            case "BulletIce":
                FXSpawner.Instance.SpawnOnCalled("ImpactIce", position);
                break;
            case "BulletFire":
                FXSpawner.Instance.SpawnOnCalled("ImpactFire", position);
                break;
            case "BulletWind":
                FXSpawner.Instance.SpawnOnCalled("ImpactWind", position);
                break;
            case "BulletLight":
                FXSpawner.Instance.SpawnOnCalled("ImpactLight", position);
                break;
            case "BulletEarth":
                FXSpawner.Instance.SpawnOnCalled("ImpactEarth", position);
                break;
        }
        return;
    }

}
