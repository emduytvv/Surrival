using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetDespawn : Despawn
{

    protected override bool CanDespawn()
    {
        return false;
    }
    //CALL Ở ANIMATION DIE
    public override void DespawnObject()
    {
        PetCtrl petCtrl = transform.parent.GetComponent<PetCtrl>();
        // DropItem(enemyCtrl);
        petCtrl.SetisAlive(false);
        PetSpawner.Instance.Despawn(transform.parent);
    }
    // private void DropItem(EnemyCtrl enemyCtrl)
    // {
    //     List<DropTable> dropTable = enemyCtrl.EnemyData.DropTable;
    //     ItemSpawner.Instance.SpawnOnCalled(dropTable, transform);
    // }
}
