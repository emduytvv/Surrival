using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : ObjectCtrl
{
    public bool isAlive = true;
    public void SetisAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    [SerializeField] protected PlayerDamageSender playerDamageSender;
    public PlayerDamageSender PlayerDamageSender => playerDamageSender;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerMovement();
        LoadPlayerDamageSender();
    }
    private void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlayerMovement()", gameObject);
    }
    private void LoadPlayerDamageSender()
    {
        if (playerDamageSender != null) return;
        playerDamageSender = GetComponentInChildren<PlayerDamageSender>();
        Debug.LogWarning(transform.name + ": LoadPlayerDamageSender()", gameObject);
    }
}
