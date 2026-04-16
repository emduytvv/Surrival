using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{

    //CALL Ở ANIMATION DIE
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
    // private void DropItem(EnemyCtrl enemyCtrl)
    // {
    //     List<DropTable> dropTable = enemyCtrl.EnemyData.DropTable;
    //     ItemSpawner.Instance.SpawnOnCalled(dropTable, transform);
    // }
}
