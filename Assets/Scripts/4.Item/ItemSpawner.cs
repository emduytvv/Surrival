
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [Header("ItemSpawner")]
    protected static ItemSpawner instance;
    public static ItemSpawner Instance => instance;
    protected override void ResetValue()
    {
        base.ResetValue();
        maxObject = 100;
    }
    protected override void Awake()
    {
        base.Awake();
        ItemSpawner.instance = this;
    }
    public virtual void SpawnOnCalled(List<DropTable> dropTable, Transform obj)
    {
        string objectName = dropTable[Random.Range(0, dropTable.Count)].itemProfile.itemCode.ToString();
        SpawnByName(objectName, obj.position, obj.rotation);
    }
}
