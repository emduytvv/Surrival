using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupable : ObjectAbstract
{
    [SerializeField] protected Transform player;
    protected override void Start()
    {
        base.Start();
        this.player = ObjectReference.Instance.Player.transform;
    }
    public virtual void PickUp()
    {
        ObjectCtrl.Despawn.DespawnObject();
    }
}
