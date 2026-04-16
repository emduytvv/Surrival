using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStone : BaseText
{
    [SerializeField] protected float currentStone;
    [SerializeField] protected PlayerStone playerStone;

    protected override void Start()
    {
        LoadPlayerStone();
    }

    protected override void Update()
    {
        base.Update();
        GetStone();
    }

    private void LoadPlayerStone()
    {
        playerStone = ObjectReference.Instance.Player.transform.GetComponentInChildren<PlayerStone>();
    }

    public void GetStone()
    {
        currentStone = playerStone.CurrentStone;
    }

    protected override void ShowText()
    {
        textMeshProUGUI.text = currentStone.ToString();
    }
}
