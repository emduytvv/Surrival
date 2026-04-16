using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReference : SaiMonoBehaviour
{
    protected static ObjectReference instance;
    public static ObjectReference Instance => instance;
    [SerializeField] protected PlayerCtrl player;
    public PlayerCtrl Player => player;
    [SerializeField] protected MainHomeCtrl mainHome;
    public MainHomeCtrl MainHome => mainHome;
    protected override void Awake()
    {
        base.Awake();
        ObjectReference.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
        LoadMainHomeCtrl();
    }
    private void LoadPlayerCtrl()
    {
        if (player != null) return;
        player = FindAnyObjectByType<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl()", gameObject);
    }
    private void LoadMainHomeCtrl()
    {
        if (mainHome != null) return;
        mainHome = FindAnyObjectByType<MainHomeCtrl>();
        Debug.LogWarning(transform.name + ": LoadMainHomeCtrl()", gameObject);
    }
}
