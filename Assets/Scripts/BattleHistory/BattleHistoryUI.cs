using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BattleHistoryUI : SaiMonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private List<BattleRecord> records;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTexts();
    }
    private void LoadTexts()
    {
        if (texts.Count > 0) return;
        texts = new List<TextMeshProUGUI>();
        foreach (Transform child in transform)
        {
            texts.Add(child.GetComponent<TextMeshProUGUI>());
        }
    }
    private void OnEnable()
    {
        LoadRecords();
        ShowText();
    }
    private void LoadRecords()
    {
        records = BattleHistoryManager.Instance.GetHistoryRecords();
    }
    private void ShowText()
    {
        Debug.Log("SHOW TEXT");
        for (int i = 0; i < texts.Count; i++)
        {
            if (i >= records.Count) break;

            var r = records[i];
            texts[i].text = $"{i + 1}. {r.mapName} - {r.minute}:{r.second:00} - {(r.isWin ? "WIN" : "LOSE")} -{r.date}";
        }
    }
}