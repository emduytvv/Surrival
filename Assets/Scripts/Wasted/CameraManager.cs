using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SaiMonoBehaviour
{
    protected static CameraManager instance;
    public static CameraManager Instance => instance;
    protected override void Awake()
    {
        CameraManager.instance = this;
    }
}
