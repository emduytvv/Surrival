using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGold : BaseText
{
    [SerializeField] protected float currentGold;
    [SerializeField] protected PlayerWallet playerWallet;
    protected override void Start()
    {
        LoadPlayerDamageReceiver();
    }
    protected override void Update()
    {
        base.Update();
        GetGold();
    }
    private void LoadPlayerDamageReceiver()
    {
        playerWallet = ObjectReference.Instance.Player.transform.GetComponentInChildren<PlayerWallet>();
    }
    public void GetGold()
    {
        currentGold = playerWallet.CurrentGold;
    }
    protected override void ShowText()
    {
        textMeshProUGUI.text = currentGold.ToString();
    }
}
