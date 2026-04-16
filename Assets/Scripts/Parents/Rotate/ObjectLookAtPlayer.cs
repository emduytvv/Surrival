using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectLookAtPlayer : ObjectLookAtTarget
{
    [SerializeField] protected GameObject player;
    public GameObject Player => player;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
       
    }

    private void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.LogWarning(transform.name + ": LoadPlayer()", gameObject);
    }
    protected override void FixedUpdate()
    {
        GetPositionPlayer();
        base.FixedUpdate();
    }

    private void GetPositionPlayer()
    {
        target=player.transform;
    }
}
