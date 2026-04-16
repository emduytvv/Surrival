using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDespawn : Despawn
{
    protected override bool CanDespawn()
    {
        return false;
    }
    public override void DespawnObject()
    {
        //BlockCtrl blockCtrl = transform.parent.GetComponent<BlockCtrl>();
        // DropItem(blockCtrl);

        BlockSpawner.Instance.Despawn(transform.parent);
    }
    // private void DropItem(BlockCtrl blockCtrl)
    // {
    //     List<DropTable> dropTable = blockCtrl.EnemyData.DropTable;
    //     ItemSpawner.Instance.SpawnOnCalled(dropTable, transform);
    // }

}
