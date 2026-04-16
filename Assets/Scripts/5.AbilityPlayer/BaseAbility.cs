using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : SaiMonoBehaviour
{
    [Header("BaseAbility")]
    [SerializeField] protected float coolDown = 5f;
    [SerializeField] protected float timer = 5f;
    [SerializeField] protected bool isReady = false;
    [SerializeField] protected float damage = 1f;
    protected virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }
    protected override void Awake()
    {
        base.Awake();
    }

}
