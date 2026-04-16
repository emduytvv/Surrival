using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FXSpawner : Spawner
{
    [Header("FXSpawner")]
    // [SerializeField] private List<SpawnObjectHasTarget> enemys = new List<SpawnObjectHasTarget>();
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    protected override void Reset()
    {
        base.Reset();
        maxObject = 100;
    }
    protected override void Awake()
    {
        base.Awake();
        FXSpawner.instance = this;
    }
    public virtual void SpawnOnCalled(string name, Vector3 position)
    {
        SpawnByName(name, position, Quaternion.identity);
    }
    public virtual void SpawnFXHealing(string name, Vector3 position, Transform target)
    {
        Transform obj = SpawnByName(name, position, Quaternion.identity);
        obj.transform.GetComponentInChildren<FxMovement>().SetTarget(target);
    }
    public virtual void SpawnTextBuff(string name, Vector3 position, string text)
    {
        Transform obj = SpawnByName(name, position, Quaternion.identity);
        obj.GetComponentInChildren<TextMeshPro>().text = "+" + text;
        obj.GetComponentInChildren<TextMeshPro>().color = Color.green;
    }
    public virtual void SpawnTextReduce(string name, Vector3 position, string text)
    {
        Transform obj = SpawnByName(name, position, Quaternion.identity);
        obj.GetComponentInChildren<TextMeshPro>().text = "-" + text;
        obj.GetComponentInChildren<TextMeshPro>().color = Color.red;
    }
    public virtual void SpawnFailText(string name, Vector3 position, string text)
    {
        Transform obj = SpawnByName(name, position, Quaternion.identity);
        obj.GetComponentInChildren<TextMeshPro>().text = text;
        obj.GetComponentInChildren<TextMeshPro>().color = Color.red;
    }
}
