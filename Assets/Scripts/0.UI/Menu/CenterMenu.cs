using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenterMenu : SaiMonoBehaviour
{
    private static CenterMenu instance;
    public static CenterMenu Instance => instance;
    [SerializeField] protected Transform mapSelect;
    public Transform MapSelect => mapSelect;
    [SerializeField] protected Transform musicSetting;
    public Transform MusicSetting => musicSetting;
    [SerializeField] protected Transform menu;
    public Transform Menu => menu;
    protected override void Awake()
    {
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMapSelect();
        LoadMusicSetting();
        LoadMenu();
    }
    private void LoadMapSelect()
    {
        if (mapSelect != null) return;
        mapSelect = transform.Find("MapSelect");
        mapSelect.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadMapSelect()", gameObject);

    }
    private void LoadMusicSetting()
    {
        if (musicSetting != null) return;
        musicSetting = transform.Find("MusicSetting");
        musicSetting.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadMusicSetting()", gameObject);

    }
    private void LoadMenu()
    {
        if (menu != null) return;
        menu = transform.Find("Menu");
        menu.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadMenu()", gameObject);

    }
}
