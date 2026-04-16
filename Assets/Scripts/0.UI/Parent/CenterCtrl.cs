using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCtrl : SaiMonoBehaviour
{
    protected static CenterCtrl instance;
    public static CenterCtrl Instance => instance;
    protected override void Awake()
    {
        CenterCtrl.instance = this;
        base.Awake();

    }
    [SerializeField] protected Transform musicSetting;
    public Transform MusicSetting => musicSetting;
    [SerializeField] protected Transform pauseSetting;
    public Transform PauseSetting => pauseSetting;
    [SerializeField] protected Transform skillTreeManager;
    public Transform SkillTreeManager => skillTreeManager;
    [SerializeField] protected Transform skillTreeMainHomeManager;
    public Transform SkillTreeMainHomeManager => skillTreeMainHomeManager;
    [SerializeField] protected Transform levelUpStatsManager;
    public Transform LevelUpStatsManager => levelUpStatsManager;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMusicSetting();
        LoadPauseSetting();
        LoadSkillTreeManager();
        LoadSkillTreeMainHomeManager();
        LoadLevelUpStatsManager();
    }
    private void LoadMusicSetting()
    {
        if (musicSetting != null) return;
        musicSetting = transform.Find("MusicSetting");
        musicSetting.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadMusicSetting()", gameObject);
    }
    private void LoadPauseSetting()
    {
        if (pauseSetting != null) return;
        pauseSetting = transform.Find("PauseSetting");
        pauseSetting.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadPauseSetting()", gameObject);
    }
    private void LoadSkillTreeManager()
    {
        if (skillTreeManager != null) return;
        skillTreeManager = transform.Find("SkillTreeManager");
        skillTreeManager.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadSkillTreeManager()", gameObject);
    }
    private void LoadLevelUpStatsManager()
    {
        if (levelUpStatsManager != null) return;
        levelUpStatsManager = transform.Find("LevelUpStatsManager");
        Debug.LogWarning(transform.name + ": LoadLevelUpStatsManager()", gameObject);
    }
    private void LoadSkillTreeMainHomeManager()
    {
        if (skillTreeMainHomeManager != null) return;
        skillTreeMainHomeManager = transform.Find("SkillTreeMainHomeManager");
        skillTreeMainHomeManager.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadSkillTreeMainHomeManager()", gameObject);
    }
}
