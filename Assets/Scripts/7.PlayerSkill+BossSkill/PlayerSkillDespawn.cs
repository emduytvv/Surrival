using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        PlayerSkillSpawner.Instance.Despawn(transform.parent);
    }
}
