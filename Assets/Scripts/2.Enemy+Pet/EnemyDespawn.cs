using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn
{

    protected override bool CanDespawn()
    {
        return false;
    }
    //CALL Ở ANIMATION DIE
    public override void DespawnObject()
    {
        EnemyCtrl enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        DropItem(enemyCtrl);

        // enemyCtrl.SetisAlive(false);
        EnemySpawner.Instance.Despawn(transform.parent);
    }
    private void DropItem(EnemyCtrl enemyCtrl)
    {
        List<DropTable> dropTable = enemyCtrl.ObjectDropData.DropTable;
        ItemSpawner.Instance.SpawnOnCalled(dropTable, transform);
    }
}
