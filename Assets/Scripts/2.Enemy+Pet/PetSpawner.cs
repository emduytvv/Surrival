using System;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : Spawner
{
    [Header("PetSpawner")]
    [SerializeField] private List<Target> pets = new List<Target>();
    protected static PetSpawner instance;
    public static PetSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        LoadDataEnemy();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        maxObject = 4;
    }
    protected void LoadDataEnemy()
    {
        pets = new List<Target>()
        {
            new Target { objectName = "Angle", target=ObjectReference.Instance.Player.transform},
            new Target { objectName = "Dog", target=null},
            new Target { objectName = "Bear", target=null},
            new Target { objectName = "Bird", target=null},
        };
    }
    // protected override void SpawnRandom()
    // {
    //     float dt = Time.deltaTime;
    //     foreach (var pet in pets)
    //     {
    //         //CheckTime
    //         pet.timer += dt;
    //         if (pet.timer < pet.timeSpawn) continue;
    //         pet.timer = 0f;
    //         //Check MaxObject
    //         if (currentObject >= maxObject) continue;
    //         //Check Point
    //         currentPoint = GetPointsRandom();
    //         if (currentPoint == null) continue;
    //         //Spawn
    //         Transform obj = SpawnByName(pet.objectName, currentPoint.position, Quaternion.identity);
    //         if (obj == null) continue;
    //         //Set Alive
    //         PetCtrl petCtrl = obj.GetComponent<PetCtrl>();
    //         if (petCtrl != null) petCtrl.SetisAlive(true);
    //         if (!pet.target) continue;
    //         obj.GetComponentInChildren<MovementToTarget>().SetTarget(pet.target);
    //     }
    // }
    public virtual void SpawnOnCall(string name, Vector3 pos)
    {
        Transform obj = SpawnByName(name, pos, Quaternion.identity);
        SetAlive(obj);
        SetTarget(obj, name);
    }
    private void SetTarget(Transform obj, string name)
    {
        foreach (var pet in pets)
        {
            if (pet.objectName != name) continue;
            if (!pet.target) return;
            obj.GetComponentInChildren<MovementToTarget>().SetTarget(pet.target);
        }
    }
    private void SetAlive(Transform obj)
    {
        PetCtrl petCtrl = obj.GetComponent<PetCtrl>();
        if (petCtrl != null) petCtrl.SetisAlive(true);
    }

}
[System.Serializable]
public class Target
{
    public string objectName;
    public Transform target;
}
