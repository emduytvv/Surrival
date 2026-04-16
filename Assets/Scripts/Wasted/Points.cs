using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : SaiMonoBehaviour
{
    [SerializeField] protected List<Transform> listPoints;
    public List<Transform> ListPoints => listPoints;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.listPoints = new List<Transform>();
        foreach (Transform item in transform)
        {
            this.listPoints.Add(item);
        }
    }
}
