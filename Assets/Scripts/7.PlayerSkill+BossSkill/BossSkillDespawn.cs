using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        BossSkillSpawner.Instance.Despawn(transform.parent);
    }
}
