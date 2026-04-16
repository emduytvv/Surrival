using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : SaiMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform FolderPrefabs;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform Holder;
    [SerializeField] protected List<Transform> pools;
    [SerializeField] protected int currentObject;
    [SerializeField] protected int maxObject = 10;


    protected override void Start()
    {
        base.Start();
        // SpawnByTransform(prefabs[0], Vector3.zero, Quaternion.identity);
        // SpawnByName("Enemy_2", Vector3.right, Quaternion.identity);

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadFolderPrefabs();
        Loadprefabs();
        LoadHolder();
    }
    protected virtual void LoadFolderPrefabs()
    {
        if (FolderPrefabs != null) return;
        FolderPrefabs = transform.Find("Prefabs");
        Debug.LogWarning(transform.name + ": LoadFolderPrefabs()", gameObject);
    }
    protected virtual void LoadHolder()
    {
        if (Holder != null) return;
        Holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder()", gameObject);
    }
    protected virtual void Loadprefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach (Transform prefab in FolderPrefabs)
        {
            prefabs.Add(prefab);
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform SpawnByName(string name, Vector3 position, Quaternion rotation)
    {
        if (currentObject >= maxObject) return null;
        Transform prefab = GetTransformByName(name);
        Transform obj = SpawnByTransform(prefab, position, rotation);
        return obj;
    }
    public virtual Transform SpawnByTransform(Transform prefab, Vector3 position, Quaternion rotation)
    {
        if (currentObject >= maxObject) return null;
        Transform obj = GetObjectFromPool(prefab);
        obj.gameObject.SetActive(true);
        obj.SetPositionAndRotation(position, rotation);
        //z=0
        Vector3 pos = obj.position;
        pos.z = 0f;
        obj.position = pos;

        currentObject++;
        return obj;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform pool in pools)
        {
            if (pool.name == prefab.name)
            {
                pools.Remove(pool);
                return pool;
            }
        }
        Transform prefabClone = Instantiate(prefab, Holder);
        prefabClone.name = prefab.name;
        return prefabClone;
    }
    protected virtual Transform GetTransformByName(string name)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == name) return prefab;
        }
        Debug.LogWarning(transform.name + ": Not found prefab name:" + name, gameObject);
        return null;
    }
    public virtual void Despawn(Transform prefab)
    {
        if (pools.Contains(prefab)) return;
        prefab.gameObject.SetActive(false);
        pools.Add(prefab);
        currentObject--;
    }

}
