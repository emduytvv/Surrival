using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class BattleHistoryManager : SaiMonoBehaviour
{
    protected static BattleHistoryManager instance;
    public static BattleHistoryManager Instance => instance;

    private BattleHistory history = new BattleHistory();
    public BattleHistory History => history;
    private string savePath => Application.persistentDataPath + "/history.json";

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddRecord(string mapName, int minute, int second, bool isWin)
    {
        BattleRecord record = new BattleRecord();
        record.mapName = mapName;
        record.minute = minute;
        record.second = second;
        record.date = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        record.isWin = isWin;

        history.records.Add(record);

        // chỉ giữ 10 trận gần nhất
        if (history.records.Count > 10)
            history.records.RemoveAt(0);

        Save();
    }
    private void Save()
    {
        string json = JsonUtility.ToJson(history, true);
        File.WriteAllText(savePath, json);
    }
    public void Load()
    {
        if (!File.Exists(savePath)) return;
        string json = File.ReadAllText(savePath);
        history = JsonUtility.FromJson<BattleHistory>(json);
    }
    public List<BattleRecord> GetHistoryRecords()
    {
        Load();
        return history.records;
    }

}