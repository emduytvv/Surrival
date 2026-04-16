using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPetForMove : Points
{
    protected static PointsPetForMove instance;
    public static PointsPetForMove Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        PointsPetForMove.instance = this;
    }
}
