using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDespawn : Despawn
{

    protected override bool CanDespawn()
    {
        return false;
    }
    //CALL Ở ANIMATION DIE
    public override void DespawnObject()
    {
        BossCtrl bossCtrl = transform.parent.GetComponent<BossCtrl>();
        DropItem(bossCtrl);

        // enemyCtrl.SetisAlive(false);
        BossSpawner.Instance.Despawn(transform.parent);
    }
    private void DropItem(BossCtrl bossCtrl)
    {
        List<DropTable> dropTable = bossCtrl.ObjectDropData.DropTable;
        ItemSpawner.Instance.SpawnOnCalled(dropTable, transform);
    }
}
