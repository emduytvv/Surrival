using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupZone : SaiMonoBehaviour
{
    [SerializeField] protected PlayerResources playerResources;
    public PlayerResources PlayerResources => playerResources;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerResources();
    }
    private void LoadPlayerResources()
    {
        if (playerResources != null) return;
        playerResources = transform.parent.GetComponent<PlayerResources>();
        Debug.LogWarning(transform.name + ": LoadPlayerResources()", gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<ItemPickupable>()) return;
        ItemPickupable item = collision.GetComponent<ItemPickupable>();

        String nameOfItem = item.transform.parent.name;
        // Debug.Log(nameOfItem);
        CheckName(nameOfItem);

        item.PickUp();
    }

    private void CheckName(string name)
    {
        switch (name)
        {
            case "Coin":
                PlayerResources.PlayerWallet.AddGold(2);
                break;
            case "Exp":
                PlayerResources.PlayerExperience.AddExp(2);
                break;
            case "Energy":
                PlayerResources.PlayerEnergy.AddEnergy(2);
                break;
            case "Boots":
                PlayerResources.PlayerMovement.AddStackBoots();
                break;
            case "Book":
                PlayerResources.PlayerBook.AddBook(1);
                break;
            case "Stone":
                PlayerResources.PlayerStone.AddStone(1);
                break;
        }
    }

}
