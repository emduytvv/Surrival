using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public abstract class BaseSkillUnlock : SaiMonoBehaviour
{
    [SerializeField] public bool unLock = false;
    public abstract void CheckUnlock();
    public abstract void SetTextUnlock();
    protected virtual void OnNotEnough(string nameText)
    {
        Debug.Log(nameText);
        FXSpawner.Instance.SpawnFailText("FailText", CameraManager.Instance.transform.position, nameText);
    }
}