
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class LevelUpStatsManager : SaiMonoBehaviour
{
    public static LevelUpStatsManager Instance => instance;
    protected static LevelUpStatsManager instance;
    public List<LevelUpStats> levelUpStatses;
    public List<Transform> panelSelections;
    protected List<int> numberRandom = new List<int>();
    private PlayerCtrl playerCtrl;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        LoadPlayerCtrl();
        OnLevelUp();
        // Invoke("HidePanel", 5f);
        // Invoke("ResetListNumberRandom", 5f);
    }
    protected virtual void LoadPlayerCtrl()
    {
        playerCtrl = ObjectReference.Instance.Player;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUpgradeStats();
        LoadPanelSelection();
    }
    protected virtual void LoadPanelSelection()
    {
        if (panelSelections.Count > 0) return;
        Transform panelSelection = transform.Find("PanelSelection");
        foreach (Transform child in panelSelection)
        {
            panelSelections.Add(child);
            child.gameObject.SetActive(false);
        }
        Debug.LogWarning(transform.name + ": LoadPanelSelection()", gameObject);
    }
    protected void LoadUpgradeStats()
    {
        if (levelUpStatses.Count > 0) return;
        LevelUpStats panel;
        Transform UpgradeStats = transform.Find("UpgradeStats");
        foreach (Transform child in UpgradeStats)
        {
            if (panel = child.GetComponent<LevelUpStats>())
            {
                levelUpStatses.Add(panel);
            }
        }
        Debug.LogWarning(transform.name + ": LoadUpgradeStats()", gameObject);
    }
    public virtual void UpgradeOnClick(string name)
    {
        int panelSelected = CheckPanelSelected(name);
        LevelUpStats levelUpStatsSelected = GetlevelUpStatsSelected(panelSelected);

        switch (levelUpStatsSelected.name)
        {
            case "DonateBook":
                playerCtrl.GetComponentInChildren<PlayerBook>().AddBook(levelUpStatsSelected.StatsUpgradeDataSO.donateBook);
                break;
            case "DonateGold":
                playerCtrl.GetComponentInChildren<PlayerWallet>().AddGold(levelUpStatsSelected.StatsUpgradeDataSO.donateGold);
                break;
            case "DonateStone":
                playerCtrl.GetComponentInChildren<PlayerStone>().AddStone(levelUpStatsSelected.StatsUpgradeDataSO.donateStone);
                break;
            case "UpgradeDamage":
                playerCtrl.GetComponentInChildren<PlayerDamageSender>().AddDamage(levelUpStatsSelected.StatsUpgradeDataSO.upgradeDamage);
                break;
            case "UpgradeMaxHP":
                playerCtrl.GetComponentInChildren<PlayerDamageReceiver>().AddMaxHP(levelUpStatsSelected.StatsUpgradeDataSO.upgradeMaxHP);
                break;
            case "UpgradeMaxMana":
                playerCtrl.GetComponentInChildren<PlayerEnergy>().AddMaxEnergy(levelUpStatsSelected.StatsUpgradeDataSO.upgradeMaxMana);
                break;
            case "UpgradeMaxSpeed":
                playerCtrl.GetComponentInChildren<PlayerMovement>().AddSpeed(levelUpStatsSelected.StatsUpgradeDataSO.upgradeSpeed);
                break;
            case "UpgradePercentSpeed":
                playerCtrl.GetComponentInChildren<PlayerMovement>().AddPercentSpeed(levelUpStatsSelected.StatsUpgradeDataSO.upgradePercentSpeed);
                break;
            case "UpgradePercentDamage":
                playerCtrl.GetComponentInChildren<PlayerDamageSender>().AddPercentDamage(levelUpStatsSelected.StatsUpgradeDataSO.upgradePercentDamage);
                break;
            case "UpgradePercentHP":
                playerCtrl.GetComponentInChildren<PlayerDamageReceiver>().AddPercentHP(levelUpStatsSelected.StatsUpgradeDataSO.upgradePercentHP);
                break;
            case "UpgradePercentMana":
                playerCtrl.GetComponentInChildren<PlayerEnergy>().AddPercentEnergy(levelUpStatsSelected.StatsUpgradeDataSO.upgradePercentMana);
                break;
        }
        HidePanel();
        ResetListNumberRandom();
    }
    private void HidePanel()
    {
        for (int i = 0; i < panelSelections.Count; i++)
        {
            panelSelections[i].gameObject.SetActive(false);
        }
    }
    private void ResetListNumberRandom()
    {
        numberRandom = new List<int>();
    }
    private LevelUpStats GetlevelUpStatsSelected(int panelSelection)
    {
        int idInRandom = numberRandom[panelSelection];
        LevelUpStats levelUpStatsSelected1 = levelUpStatses[idInRandom];
        return levelUpStatsSelected1;
    }

    protected int CheckPanelSelected(string name)
    {
        switch (name)
        {
            case "BtnPanelSelection_1":
                return 0;
            case "BtnPanelSelection_2":
                return 1;
            case "BtnPanelSelection_3":
                return 2;
            default:
                Debug.LogWarning(transform.name + ": CheckPanelSelection()", gameObject);
                return -1;
        }
    }
    public virtual void OnLevelUp()
    {
        ShowPanel();
    }
    protected virtual void ShowPanel()
    {
        GetRandom3Number(numberRandom);
        for (int i = 0; i < numberRandom.Count; i++)
        {
            SetPanel(i);
        }
    }
    protected virtual void SetPanel(int i)
    {
        panelSelections[i].gameObject.SetActive(true);
        panelSelections[i].GetComponentInChildren<TextMeshProUGUI>().text = levelUpStatses[numberRandom[i]].StatsUpgradeDataSO.description;
        panelSelections[i].Find("Image").GetComponent<Image>().sprite = levelUpStatses[numberRandom[i]].StatsUpgradeDataSO.sprite;

    }
    protected void GetRandom3Number(List<int> numberRandom)
    {
        while (numberRandom.Count < 3)
        {
            int number = Random.Range(0, levelUpStatses.Count);
            if (!numberRandom.Contains(number))
            {
                numberRandom.Add(number);
            }
        }
    }

}
